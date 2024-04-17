using Shortly.Client.Data.Helpers;

namespace Shortly.Client.Data.ViewModels
{
    public class ConfirmEmailLoginVM
    {
        [CustomEmailValidator(ErrorMessage = "Email address is not valid")]
        public string EmailAddress { get; set; }
    }
}
