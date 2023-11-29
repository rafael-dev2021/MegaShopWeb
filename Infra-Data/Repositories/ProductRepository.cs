using Domain.Entities;
using Domain.Entities.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _appDbContext.Products
               .Include(review => review.Reviews)
               .Include(category => category.Category)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products
                .AsNoTracking()
                .Include(x => x.Reviews)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBestSellersAsync()
        {
            IEnumerable<Product> _products = await GetProductsAsync();

            if (_products == null)
            {
                throw new InvalidOperationException("Products list is null.");
            }

            return _products
                .Where(item => item.ProductFlagsObjectValue.IsBestSeller == true)
                .OrderBy(x => x.Id)
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

        public async Task<IEnumerable<Product>> GetProductsDailyOffersAsync()
        {
            IEnumerable<Product> _products = await GetProductsAsync();

            if (_products == null)
            {
                throw new InvalidOperationException("Products list is null.");
            }

            return _products
                .Where(item => item.ProductFlagsObjectValue.IsDailyOffer == true)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsFavoritesAsync()
        {
            IEnumerable<Product> _products = await GetProductsAsync();

            if (_products == null)
            {
                throw new InvalidOperationException("Products list is null.");
            }

            return _products
                .Where(item => item.ProductFlagsObjectValue.IsFavorite == true)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public async Task<IEnumerable<Product>> GetSearchProductAsync(string keyword)
        {
            // Buscar os produtos do banco sem aplicar o filtro
            var products = await _appDbContext.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .ToListAsync();

            // Filtrar os produtos no lado do cliente usando LINQ
            var filteredProducts = products
                .Where(x =>
                    x.Name.ToLower().Contains(keyword.ToLower()) ||
                    x.Category.CategoryName.ToLower().Contains(keyword.ToLower()) ||
                    (x.ProductSpecificationsObjectValue != null &&
                        (x.ProductSpecificationsObjectValue.ProductBrand.ToLower().Contains(keyword.ToLower()) ||
                         x.ProductSpecificationsObjectValue.ProductModel.ToLower().Contains(keyword.ToLower())))
                )
                .OrderBy(x => x.Id);

            return filteredProducts;
        }

    }
}
