using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.IdentityViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$+!%*?&])[A-Za-z\d@$+!%*?&]{8,}$",
           ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit and one special character and be at least 8 characters long.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$+!%*?&])[A-Za-z\d@$+!%*?&]{8,}$",
           ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit and one special character and be at least 8 characters long.")]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
