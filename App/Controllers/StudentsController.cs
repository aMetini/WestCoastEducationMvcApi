using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using App.Entities;
using App.Interfaces;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentservice;
        public StudentsController(IUnitOfWork unitOfWork, IStudentService studentservice)
        {
            _studentservice = studentservice;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
    public async Task<IActionResult> Index(string searchString)
    {
      var result = await _studentservice.GetStudentsAsync();

      if(!string.IsNullOrEmpty(searchString))
      {
        var resultFiltered = result.Where(c => c.Email.Contains(searchString));
        return View("Index", resultFiltered);
      } 
      return View("Index", result);
    }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            var list = await _unitOfWork.CourseRepository.GetCoursesAsync();
            return View("Create");
        }

        [HttpPost()]
        public async Task<IActionResult> Create(RegisterStudentViewModel data)
        {
            if (!ModelState.IsValid) return View("Create", data);

            var student = new StudentModel
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                MobileNumber = data.MobileNumber,
                AddressInformation = data.AddressInformation,
                PersonalNumber = data.PersonalNumber,
                CourseId = data.CourseId
            };
            try
            {
                if(await _studentservice.AddStudent(student)) return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentservice.GetStudentAsync(id);

            var model = new EditStudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                MobileNumber = student.MobileNumber,
                AddressInformation = student.AddressInformation,
                PersonalNumber = student.PersonalNumber,
                CourseId = student.CourseId
            };
            return View("Edit", model);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(EditStudentViewModel data)
        {
            try
            {
                var student = await _studentservice.GetStudentAsync(data.Id);

                var studentModel = new UpdateStudentViewModel
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    MobileNumber = data.MobileNumber,
                    AddressInformation = data.AddressInformation,
                    PersonalNumber = data.PersonalNumber,
                    CourseId = data.CourseId
                };

                if (await _studentservice.UpdateStudent(data.Id, studentModel)) return RedirectToAction("Index");

                return RedirectToAction("Error");
            }
            catch (System.Exception)
            {
                return View("Error");                
            }
        }

        // [HttpGet("find/{email}")]
        public async Task<IActionResult> Details(string studentEmail)
        {
            var result = await _studentservice.GetStudentAsync(studentEmail);
            if(result != null) return Content($"Student Details: {studentEmail}\n" +
            $" - First Name: {result.FirstName}\n" +
            $" - Last Name: {result.LastName}\n" +
            $" - Mobile Number: {result.MobileNumber}\n" +
            $" - Address Information: {result.AddressInformation}\n" +
            $" - Personal Number: {result.PersonalNumber}\n" +
            $" - Course ID: {result.CourseId}");

            return Content($"Unable to find student with email address: {studentEmail}");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _studentservice.DeleteStudent(id)) return RedirectToAction("Index");
            return View("Error");
        }

    }
}