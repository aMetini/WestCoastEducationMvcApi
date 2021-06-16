using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
  public class RegisterStudentViewModel
    {
    [Display(Name = "Id")]
    [Required(ErrorMessage = "Id must be indicated!")]
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName {get; set; }
    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name must be indicated!")]
    public string LastName { get; set; }
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email must be indicated!")]
    public string Email {get; set; }
    [Display(Name = "Mobile Number")]
    public int MobileNumber { get; set; }
    [Display(Name = "Address Information")]
    public string AddressInformation { get; set; }
    [Display(Name = "Personal Number")]
    [Required(ErrorMessage = "Personal number must be indicated!")]
    public int PersonalNumber{ get; set; }
  }
}