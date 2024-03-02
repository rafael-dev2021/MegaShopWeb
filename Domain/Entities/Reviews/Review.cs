namespace Domain.Entities.Reviews;

public sealed class Review(int reviewId, string comment, string image, int rating, DateTime reviewDate, int productId)
{
    public int ReviewId { get; set; } = reviewId;
    public string Comment { get; private set; } = comment;
    public string Image { get; private set; } = image;
    public int Rating { get; private set; } = rating;
    public DateTime ReviewDate { get; private set; } = reviewDate;
    public int ProductId { get; set; } = productId;
    public Product Product { get; set; }
}
