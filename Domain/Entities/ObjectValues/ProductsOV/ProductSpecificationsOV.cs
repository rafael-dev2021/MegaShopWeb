using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities.ObjectValues.ProductsOV
{
    public class ProductSpecificationsOV
    {
        [Required(ErrorMessage = "Product model is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Product model")]
        public string ProductModel { get; protected set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Brand")]
        public string ProductBrand { get; protected set; } = string.Empty;

        [Required(ErrorMessage = "Product line is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Product line")]
        public string ProductLine { get; protected set; } = string.Empty;

        [Required(ErrorMessage = "Product weight is required.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
        [DisplayName("Product weight")]
        public string ProductWeight { get; protected set; } = string.Empty;
        public string ProductType { get; protected set; } = string.Empty;

    }
}
