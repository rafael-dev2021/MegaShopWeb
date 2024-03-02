using Application.Dtos;

namespace Application.Services.PriceIsHigherThan.Interfaces;

public interface IPriceIsHigherThanService
{
    Task<IEnumerable<ProductDto>> GetProductsAbovePriceAsync(decimal price);
    Task<IEnumerable<ProductDto>> GetProductsBelowPriceAsync(decimal price);
    Task<IEnumerable<ProductDto>> GetProductsAboveOrBelowPriceAsync(decimal price, decimal secondPrice);
}
