namespace Domain.Entities.Reviews
{
    public sealed class Review(int reviewId, string comment, string image, int rating, DateTime reviewDate, int productReviewId)
    {
        public int ReviewId { get; private set; } = reviewId;
        public string Comment { get; private set; } = comment;
        public string Image { get; private set; } = image;
        public int Rating { get; private set; } = rating;
        public DateTime ReviewDate { get; private set; } = reviewDate;
        public int ProductReviewId { get; set; } = productReviewId;
        public Product Product { get; set; }
    }
}
