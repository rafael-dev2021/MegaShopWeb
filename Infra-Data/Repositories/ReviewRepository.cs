using Domain.Entities.Reviews;
using Domain.Interfaces.Reviews;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly AppDbContext _appDbContext;

        public ReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await _appDbContext.Reviews
                .AsNoTracking()
                .Include(x => x.Product)
                .ToListAsync();
        }
        public async Task<Review> CreateReview(Review review)
        {
            _appDbContext.Add(review);
            await _appDbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetByIdAsync(int? id)
        {
            return await _appDbContext.Reviews
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.ReviewId == id);
        }

        public async Task<Review> RemoveReview(Review review)
        {
            _appDbContext.Remove(review);
            await _appDbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateReview(Review review)
        {
            _appDbContext.Update(review);
            await _appDbContext.SaveChangesAsync();
            return review;
        }
    }
}
