using Application.Dtos;
using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Dtos.ProductsDto.Fashion.Tshirts;
using Application.Dtos.ProductsDto.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Smartphones;
using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews.ValueObjects;
using Application.Services.CountProductByPrice.ObjectsValue;
using Application.Services.Discounts.ValueObjects;
using Application.Services.GetMatchingProducts.Fashion;
using Application.Services.GetMatchingProducts.Technology;
using Application.Services.PriceIsHigherThan;

namespace WebUI.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> ProductsDto { get; set; }
        public IEnumerable<SmartphoneDto> SmartphonesDto { get; set; }
        public IEnumerable<ReviewDto> ReviewsDto { get; set; }
        public IEnumerable<GameDto> GamesDto { get; set; }
        public IEnumerable<ShoesDto> ShoesDtos { get; set; }
        public IEnumerable<TshirtDto> TshirtsDto { get; set; }
        public ProductDto ProductDto { get; set; }
        public SmartphoneDto SmartphoneDto { get; set; }
        public GetMatchingProductsDtoTechnology GetMatchingProductsDto { get; set; }
        public GetMatchingProductsDtoFashion GetMatchingProductsDtoFashion { get; set; }

        public CountProductByPriceOV CountProductByPriceOV { get; set; }
        public PriceIsHigherThanServiceBooleans PriceIsHigherThanServiceBooleans { get; set; }
        public CalculateDiscountOV CalculateDiscountOV { get; set; }

        public string CurrentCategory { get; set; }
        public string CurrentBrand { get; set; }
    }
}
