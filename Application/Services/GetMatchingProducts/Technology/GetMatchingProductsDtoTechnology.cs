using Application.Dtos;
using Application.Dtos.ProductsDto.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Smartphones;

namespace Application.Services.GetMatchingProducts.Technology;

public class GetMatchingProductsDtoTechnology
{
    public ProductDto ProductDto { get; set; }
    public IEnumerable<SmartphoneDto> SmartphonesDto { get; set; }
    public IEnumerable<GameDto> GamesDto { get; set; }

    public IEnumerable<T> GetMatchingProducts<T>(IEnumerable<T> productsDto) where T : ProductDto
    {
        return productsDto
            .Where(x =>
            x.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
            x.Category.CategoryName == ProductDto.Category.CategoryName);
    }
    public IEnumerable<SmartphoneDto> GetMatchingSmartphonesDto()
    {
        return GetMatchingProducts(SmartphonesDto);
    }

    public IEnumerable<GameDto> GetMatchingGamesDto()
    {
        return GetMatchingProducts(GamesDto);
    }
}
