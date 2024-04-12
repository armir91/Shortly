using Shortly.Client.Data.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Shortly.Client.Data.ViewModels
{
    public class LoginVM
    {
        /*[Required(ErrorMessage="Email is required")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]*/
        [CustomEmailValidator(ErrorMessage = "Email address is not valid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long!")]
        public string Password { get; set; }
    }
}
