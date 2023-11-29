using Application.Interfaces.Entities;
using Application.Services.CountProductByPrice.Interfaces;

namespace Application.Services.CountProductByPrice
{
    public class CountProductsByPriceService : ICountProductsByPriceService
    {
        private readonly IProductDtoService _productDtoService;

        public CountProductsByPriceService(IProductDtoService productDtoService)
        {
            _productDtoService = productDtoService;
        }

        public async Task<int> CountingProductsAboveOrBelowPriceAsync(decimal price, decimal secondPrice)
        {
            var listProducts = await _productDtoService.GetProductsDtoAsync();
            var count = listProducts
                .Count(x => x.ProductPriceObjectValue.Price >= price && x.ProductPriceObjectValue.Price <= secondPrice);

            return count;
        }

        public async Task<int> CountingProductsBelowPriceAsync(decimal price)
        {
            var listProducts = await _productDtoService.GetProductsDtoAsync();
            var count = listProducts.Count(x => x.ProductPriceObjectValue.Price <= price);
            return count;
        }

        public async Task<int> CountingProductsAbovePriceAsync(decimal price)
        {
            var listProducts = await _productDtoService.GetProductsDtoAsync();
            var count = listProducts.Count(x => x.ProductPriceObjectValue.Price >= price);
            return count;
        }

        //public async Task<int> CountProductsAbovePriceAsync(decimal price)
        //{
        //    var listProducts = await _productDtoService.GetProductsDtoAsync();
        //    var count = listProducts.Where(x => x.PriceValueObject.Price >= price).Count();
        //    return count;
        //}
    }
}
