using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.ProductsRepository.Fashion;

public class TshirtRepository(AppDbContext appDbContext) : ITshirtRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Tshirt>> GetProductsAsync()
    {
        return await _appDbContext.Tshirts
           .AsNoTracking()
           .Include(x => x.Category)
           .Include(x => x.Reviews)
           .OrderBy(x => x.Name)
           .ToListAsync();
    }

    public async Task<Tshirt> GetByIdAsync(int? id) =>
       await _appDbContext.Tshirts.FindAsync(id);

    public async Task<Tshirt> UpdateAsync(Tshirt entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Tshirt> CreateAsync(Tshirt entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Tshirt> DeleteAsync(Tshirt entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}
