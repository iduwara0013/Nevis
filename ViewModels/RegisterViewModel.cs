using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.ViewModels
{
    public class RegisterViewModel
    {
         [Key]  // Primary Key annotation
         public int Id { get; set; }
        public string FirstName { get; set; }   // Added
        public string LastName { get; set; }    // Added
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }  // Added
        public string PhoneNumber { get; set; }    // Added
    }
}
