using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    // This view model class consists of all properties required by the Create view in the Courses Page.
    public class RegisterCourseViewModel
    {
    [Display(Name = "Id")]
    [Required(ErrorMessage = "Id must be indicated!")]
    public int Id { get; set; }
    [Display(Name = "Course Number")]
    [Required(ErrorMessage = "Course number must be indicated!")]
    public int CourseNumber { get; set; }
    [Display(Name = "Course Title")]
    public string Title {get; set; }
    [Display(Name = "Course Description")]
    public string Description { get; set; }
    [Display(Name = "Course Length (hrs)")]
    public int Length { get; set; }
    public string ImageName { get; set; }
    [Display(Name = "Course Category")]
    public string Category { get; set; }
    [Display(Name = "Course Level")]
    public string CourseLevel { get; set; }
    [Display(Name = "Price")]
    [Required(ErrorMessage = "Course price must be indicated!")]
    public decimal Price { get; set; }
    [Display(Name = "Course Status")]
    public string Status { get; set; }

  }
}