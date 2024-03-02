using Domain.Entities;
using Domain.Entities.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.EntitiesRepositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _appDbContext.Products
            .AsNoTracking()
            .Include(review => review.Reviews)
            .Include(category => category.Category)
            .ToListAsync();
    }
    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _appDbContext.Products
           .Include(review => review.Reviews)
           .Include(category => category.Category)
           .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<IEnumerable<Product>> GetProductsFavoritesAsync()
    {
        IEnumerable<Product> _products = await GetProductsAsync();

        return _products
            .Where(item => item.ProductFlagsObjectValue.IsFavorite == true)
            .OrderBy(x => x.Id)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsDailyOffersAsync()
    {
        IEnumerable<Product> _products = await GetProductsAsync();

        return _products
            .Where(item => item.ProductFlagsObjectValue.IsDailyOffer == true)
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsBestSellersAsync()
    {
        IEnumerable<Product> _products = await GetProductsAsync();

        return _products
            .Where(item => item.ProductFlagsObjectValue.IsBestSeller == true)
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsByCategoriesAsync(string categoryStr)
    {
        return await _appDbContext.Products
             .AsNoTracking()
             .Where(category => category.Category.CategoryName.Equals(categoryStr))
             .Include(review => review.Reviews)
             .Include(category => category.Category)
             .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetSearchProductAsync(string keyword)
    {
        var products = await _appDbContext.Products
            .AsNoTracking()
            .Include(x => x.Category)
            .ToListAsync();

        var filteredProducts = products
            .Where(x =>
                x.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                x.Category.CategoryName.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                x.ProductSpecificationsObjectValue != null && (
                x.ProductSpecificationsObjectValue.ProductBrand.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                x.ProductSpecificationsObjectValue.ProductModel.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)))
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();

        return filteredProducts;
    }

}
