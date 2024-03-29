using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
    // This interface repository stores/accesses data for the Course entity
    public interface ICourseRepository
  {
    void Add(Course course);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> GetCourseByCourseNoAsync(int courseNo);
    Task<Course> GetCourseByIdAsync(int id);
    void Update(Course course);
    void Delete(Course course);
  }
}