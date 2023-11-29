using Application.Dtos;
using Application.Dtos.ProductsDto.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Smartphones;

namespace Application.Services.GetMatchingProducts.Technology
{
    public class GetMatchingProductsDtoTechnology
    {
        public ProductDto ProductDto { get; set; }
        public IEnumerable<SmartphoneDto> SmartphonesDto { get; set; }
        public IEnumerable<GameDto> GamesDto { get; set; }

        public IEnumerable<SmartphoneDto> GetMatchingSmartphones()
        {
            var matchingSmartphones = SmartphonesDto.Where(s =>
                s.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
                s.Category.CategoryName == ProductDto.Category.CategoryName);

            return matchingSmartphones;
        }

        public IEnumerable<GameDto> GetMatchingGames()
        {
            var matchingGames = GamesDto.Where(s =>
                s.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
                s.Category.CategoryName == ProductDto.Category.CategoryName);

            return matchingGames;
        }
    }
}
