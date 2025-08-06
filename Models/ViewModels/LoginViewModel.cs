using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Benedict.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Email")]
        public string? Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        public string? Password { get; set; }
    }
}
