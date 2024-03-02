using Domain.Entities;
namespace Application.Dtos.Reviews;

public class ReviewDto
{
    public int ReviewId { get; set; }
    public string Comment { get; private set; }
    public string Image { get; private set; }
    public int Rating { get; private set; } 
    public DateTime ReviewDate { get; private set; } 
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
