using System.Collections.Generic;

namespace Api.Entities
{
  public class CourseTitle
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
  }
}