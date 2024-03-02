using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.IdentityViewModel
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "The first name must have more than 3 and less than 40 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "The last name must have more than 3 and less than 40 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "SSN is required.")]
        [StringLength(11, ErrorMessage = "SSN must be exactly 9 digits.")]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid SSN format (e.g., 123-45-6789)")]
        public string SSN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 14 characters.")]
        [RegularExpression(@"^\(?[(.]?\d{3}\)?[).]?\d{3}[-.]?\d{4}$", ErrorMessage = "Invalid phone number format. Format (xxx) xxx-xxxx")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }
    }
}
