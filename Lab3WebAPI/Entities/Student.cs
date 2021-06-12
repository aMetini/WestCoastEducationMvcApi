using System.Collections.Generic;


namespace Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public string AddressInformation { get; set; }
        public int PersonalNumber { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}