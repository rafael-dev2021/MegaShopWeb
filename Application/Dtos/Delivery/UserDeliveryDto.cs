using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Delivery;

public class UserDeliveryDto
{
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [DataType(DataType.EmailAddress)]
    [StringLength(50, MinimumLength = 10)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "Maximum and minimum 12 characters.")]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Invalid phone number format. Format: xxx-xxx-xxxx")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = string.Empty;


    [Required(ErrorMessage = "SSN is required.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "SSN must be exactly 9 digits.")]
    [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid SSN format (e.g., 123-45-6789)")]
    public string SSN { get; set; } = string.Empty;
}
