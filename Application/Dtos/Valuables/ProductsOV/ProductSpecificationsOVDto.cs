using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Dtos.Valuables.ProductsOV;

public class ProductSpecificationsOVDto
{
    [Required(ErrorMessage = "Product model is required.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
    [DisplayName("Product model")]
    public string ProductModel { get; set; } = string.Empty;

    [Required(ErrorMessage = "Brand is required.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
    [DisplayName("Brand")]
    public string ProductBrand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Product line is required.")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
    [DisplayName("Product line")]
    public string ProductLine { get; set; } = string.Empty;

    [Required(ErrorMessage = "Product weight is required.")]
    [StringLength(15, MinimumLength = 2, ErrorMessage = "Minimum {2} and maximum {1} characters.")]
    [DisplayName("Product weight")]
    //int
    public string ProductWeight { get; set; } = string.Empty;
    [Required]
    public string ProductType { get; set; } = string.Empty;

}
