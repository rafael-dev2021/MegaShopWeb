namespace Domain.Entities.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int? id);
    Task<IEnumerable<Product>> GetProductsFavoritesAsync();
    Task<IEnumerable<Product>> GetProductsDailyOffersAsync();
    Task<IEnumerable<Product>> GetProductsBestSellersAsync();
    Task<IEnumerable<Product>> GetProductsByCategoriesAsync(string categoryStr);
    Task<IEnumerable<Product>> GetSearchProductAsync(string keyword);
}
