using Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ReviewId);
            builder.Property(x => x.Comment).HasMaxLength(2000);
            builder.Property(x => x.Image).HasMaxLength(250);
            builder.HasOne(x => x.Product).WithMany(x => x.Reviews).HasForeignKey(x => x.ProductReviewId);

            builder.HasData(
                new Review(1, "The quality of the photos is incredible.", "https://http2.mlstatic.com/D_NQ_NP_637616-MLA70484274053_072023-O.webp", 5, DateTime.Now, 1),
                new Review(2, "Very good purchase, it arrived very quickly and it arrived like a totally new phone, it only has very slight details on the sides.", "https://m.media-amazon.com/images/I/71a4vqXqxbL._SY256.jpg", 5, DateTime.Now, 1),
                new Review(3, "Good!", "https://http2.mlstatic.com/D_NQ_NP_2X_743184-MLA69501979268_052023-F.webp", 4, DateTime.Now, 1),
                new Review(4, "The best smartphone I\'ve ever used!!! I left an iPhone 14 Pro Max, sold it, bought the S23 Ultra and still had money left. There\'s no comparison, with 8gb of ram you can use several applications in the background at the same time.", "https://http2.mlstatic.com/D_NQ_NP_2X_936910-MLA54765476953_032023-F.webp", 5, DateTime.Now, 2),
                new Review(5, "Excellent, after all it is an Apple product. Worth every penny given ❤.", "https://http2.mlstatic.com/D_NQ_NP_2X_960098-MLA73264672831_122023-F.webp", 5, DateTime.Now, 3),
                new Review(6, "The best.", "https://http2.mlstatic.com/D_NQ_NP_2X_911842-MLA73095448948_112023-F.webp", 4, DateTime.Now, 4),
                new Review(7, "New original product you can buy without fear!.", "https://http2.mlstatic.com/D_NQ_NP_2X_696237-MLA71736945652_092023-F.webp", 5, DateTime.Now, 5),
                new Review(8, "Excellent product, came sealed.", "https://http2.mlstatic.com/D_NQ_NP_2X_918056-MLA72166744514_102023-F.webp", 5, DateTime.Now, 5),
                new Review(9, "Perfect product.", "https://http2.mlstatic.com/D_NQ_NP_2X_661229-MLA72108620029_102023-F.webp", 5, DateTime.Now, 6),
                new Review(10, "The best product, very good!", "https://http2.mlstatic.com/D_NQ_NP_2X_942915-MLA54965635426_042023-F.webp", 4, DateTime.Now, 6),
                new Review(11, "Pay attention to size. Nike models are smaller. The ideal is to buy 1 size larger.", "", 4, DateTime.Now, 7),
                new Review(12, "It was small on me. I want to return it. To get my refund.", "", 1, DateTime.Now, 7),
                new Review(14, "Excellent product.", "", 5, DateTime.Now, 9),
                new Review(15, "I liked the original, it has to be laced but it\'s perfect.", "", 5, DateTime.Now, 10),
                new Review(16, "I\'m a fan of this sneaker. One of the most beautiful on the foot, in my opinion.", "", 4, DateTime.Now, 10)
                );
        }
    }
}
