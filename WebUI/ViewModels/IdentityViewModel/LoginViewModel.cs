using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.IdentityViewModel
{
    public class LoginViewModel
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember-me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
