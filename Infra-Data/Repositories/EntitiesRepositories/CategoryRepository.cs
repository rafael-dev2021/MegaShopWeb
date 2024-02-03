using Domain.Entities;
using Domain.Entities.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories;

public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Category>> ListItemsAsync()
    {
        return await _appDbContext.Categories
              .AsNoTracking()
              .Include(products => products.Products)
              .OrderBy(x => x.Id)
              .ToListAsync();
    }

    public async Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync()
    {
        var categoriesWithCount = await _appDbContext.Categories
            .AsNoTracking()
            .Select(category => new
             CategoryWithProductCount(category.CategoryName, category.Products.Count()))
            .ToListAsync();

        return categoriesWithCount;
    }
    public async Task<Category> GetByIdAsync(int? id)
    {
        return await _appDbContext.Categories
            .Include(products => products.Products)
            .FirstOrDefaultAsync(category => category.Id == id);
    }
    public async Task<Category> CreateAsync(Category category)
    {
        _appDbContext.Add(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }
    public async Task<Category> UpdateAsync(Category category)
    {
        _appDbContext.Update(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }
    public async Task<Category> DeleteAsync(Category category)
    {
        _appDbContext.Remove(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }

}
