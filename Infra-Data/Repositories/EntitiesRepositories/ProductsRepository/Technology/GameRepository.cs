using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Games;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories.ProductsRepository.Technology;

public class GameRepository(AppDbContext appDbContext) : IGameRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Game>> GetProductsAsync()
    {
        return await _appDbContext.Games
           .AsNoTracking()
           .Include(x => x.Category)
           .Include(x => x.Reviews)
           .OrderBy(x => x.Name)
           .ToListAsync();
    }

    public async Task<Game> GetByIdAsync(int? id) =>
        await _appDbContext.Games.FindAsync(id);

    public async Task<Game> UpdateAsync(Game entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Game> CreateAsync(Game entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Game> DeleteAsync(Game entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}
