namespace App.ViewModels
{
  public class UpdateCourseViewModel
  {
    public int CourseNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public int Length { get; set; }
    public string Category { get; set; }
    public string CourseLevel { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
  }
}