namespace Application.Services.CountProductByPrice.Interfaces;

public interface ICountProductsByPriceService
{
    Task<int> CountingProductsAbovePriceAsync(decimal price);
    Task<int> CountingProductsBelowPriceAsync(decimal price);
    Task<int> CountingProductsAboveOrBelowPriceAsync(decimal price, decimal secondPrice);
}
