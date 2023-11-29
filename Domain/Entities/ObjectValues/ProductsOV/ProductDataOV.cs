using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities.ObjectValues.ProductsOV
{
    public class ProductDataOV
    {
        [Required(ErrorMessage = "Release month is required.")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Release month")]
        public string ReleaseMonth { get; protected set; } = string.Empty;

        [Required(ErrorMessage = "Release year is required.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Release year")]
        public string ReleaseYear { get; protected set; } = string.Empty;
    }
}
