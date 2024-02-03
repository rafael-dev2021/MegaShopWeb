using Domain.Entities.Reviews;
using Domain.Interfaces.Reviews;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories;

public class ReviewRepository(AppDbContext appDbContext) : IReviewRepository
{

    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Review>> ListItemsAsync()
    {
        return await _appDbContext.Reviews
            .AsNoTracking()
            .Include(x => x.Product)
            .ToListAsync();
    }
    public async Task<Review> GetByIdAsync(int? id)
    {
        return await _appDbContext.Reviews
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.ReviewId == id);
    }

    public async Task<Review> UpdateAsync(Review review)
    {
        _appDbContext.Update(review);
        await _appDbContext.SaveChangesAsync();
        return review;
    }
    public async Task<Review> CreateAsync(Review review)
    {
        _appDbContext.Add(review);
        await _appDbContext.SaveChangesAsync();
        return review;
    }
    public async Task<Review> DeleteAsync(Review review)
    {
        _appDbContext.Remove(review);
        await _appDbContext.SaveChangesAsync();
        return review;
    }
}
