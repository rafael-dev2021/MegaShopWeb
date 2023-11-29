using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Dtos.ValueObjects.ProductsOV
{
    public class ProductImageOVDto
    {
        [Required(ErrorMessage = "Image is required.")]
        [StringLength(500, ErrorMessage = "Maximum {1} characters.")]
        [DisplayName("Main image")]
        public string? MainImage { get; set; }

        [StringLength(500, ErrorMessage = "Maximum {1} characters.")]
        public string? ImageFirst { get; set; }

        [StringLength(500, ErrorMessage = "Maximum {1} characters.")]
        public string? ImageSecond { get; set; }

        [StringLength(500, ErrorMessage = "Maximum {1} characters.")]
        public string? ImageThird { get; set; }


        //public static implicit operator ProductImageVO(string v)
        //{
        //    string[] parts = v.Split(',');

        //    var productImage = new ProductImageVO();

        //    if (parts.Length > 0)
        //        productImage.MainImage = parts[0];

        //    if (parts.Length > 1)
        //        productImage.ImageFirst = parts[1];

        //    if (parts.Length > 2)
        //        productImage.ImageSecond = parts[2];

        //    if (parts.Length > 3)
        //        productImage.ImageThird = parts[3];

        //    return productImage;
        //}
    }
}
