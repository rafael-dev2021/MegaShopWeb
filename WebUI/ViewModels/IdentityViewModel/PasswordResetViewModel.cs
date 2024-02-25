using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebUI.ViewModels.IdentityViewModel;

public class PasswordResetViewModel
{
    [Required]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(50, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$+!%*?&])[A-Za-z\d@$+!%*?&]{8,}$",
      ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit and one special character and be at least 8 characters long.")]
    [DisplayName("New password")]
    public string NewPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(50, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$+!%*?&])[A-Za-z\d@$+!%*?&]{8,}$",
      ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit and one special character and be at least 8 characters long.")]
    [DisplayName("New password")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
