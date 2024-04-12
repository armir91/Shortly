using Shortly.Client.Data.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Shortly.Client.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "The Full Name is required!")]
        public string FullName { get; set; }

        /*[Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]*/
        [CustomEmailValidator(ErrorMessage = "Email address is not valid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Confirm password does not match with the password entered!")]
        public string ConfirmPassword { get; set; }
    }
}
