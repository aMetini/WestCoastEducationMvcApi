namespace App.Models
{
    // Student model defines properties and/or methods of a Student object
    public class StudentModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string AddressInformation { get; set; }
    public string PersonalNumber { get; set; }
    public int CourseId { get; set; }
  }
}