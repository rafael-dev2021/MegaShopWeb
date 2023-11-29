using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Dtos.ValueObjects.ProductsOV
{
    public class ProductPriceOVDto
    {
        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, 999999999, ErrorMessage = "Price is invalid, minimum value $ 0.1.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Range(0.1, 999999999, ErrorMessage = "History Price is invalid, minimum value $ 0.1.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        [DisplayName("History Price")]
        public decimal HistoryPrice { get; set; }

    }
}
