using Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Reviews
{
    public class ReviewDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(2000, MinimumLength = 2, ErrorMessage = "Minimum {2} and maximum {1} characters")]
        [DisplayName("Comment")]
        public string Comment { get; set; } = string.Empty;

        [StringLength(250)]
        [DisplayName("Image")]
        public string Image { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "Maximum {2} and minimum {1}")]
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductReviewId { get; set; }
        public Product Product { get; set; }
    }
}
