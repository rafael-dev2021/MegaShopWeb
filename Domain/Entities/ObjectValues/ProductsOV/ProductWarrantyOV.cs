using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ObjectValues.ProductsOV
{
    public class ProductWarrantyOV
    {
        [Required(ErrorMessage = "Warranty length is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        public string WarrantyLength { get; protected set; } = string.Empty;

        [Required(ErrorMessage = "Warranty information is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        public string WarrantyInformation { get; protected set; } = string.Empty;

    }
}
