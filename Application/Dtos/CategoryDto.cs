using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Entities;

namespace Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum {2} and maximum {1} characters")]
        [DisplayName("Category name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [StringLength(500, ErrorMessage = "Maximum {1} characters")]
        [DisplayName("Category Image")]
        public string CategoryImage { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
