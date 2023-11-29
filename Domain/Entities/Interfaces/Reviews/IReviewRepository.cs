using Domain.Entities.Reviews;

namespace Domain.Interfaces.Reviews
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<Review> GetByIdAsync(int? id);
        Task<Review> CreateReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task<Review> RemoveReview(Review review);
    }
}
