using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ValueObjects.ProductsOV
{
    public class ProductWarrantyOVDto
    {
        [Required(ErrorMessage = "Warranty length is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        public string? WarrantyLength { get; set; }

        [Required(ErrorMessage = "Warranty information is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        public string? WarrantyInformation { get; set; }

    }
}
