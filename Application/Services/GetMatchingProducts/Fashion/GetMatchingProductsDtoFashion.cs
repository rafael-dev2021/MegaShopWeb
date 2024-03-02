using Application.Dtos;
using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Dtos.ProductsDto.Fashion.Tshirts;

namespace Application.Services.GetMatchingProducts.Fashion;

public class GetMatchingProductsDtoFashion
{
    public ProductDto ProductDto { get; set; }
    public IEnumerable<TshirtDto> TshirtsDto { get; set; }
    public IEnumerable<ShoesDto> ShoesDto { get; set; }

    public IEnumerable<T> GetMatchingProducts<T>(IEnumerable<T> productsDto) where T : ProductDto
    {
        return productsDto
            .Where(x =>
            x.ProductSpecificationsObjectValue.ProductModel == ProductDto.ProductSpecificationsObjectValue.ProductModel &&
            x.Category.CategoryName == ProductDto.Category.CategoryName);
    }
    public IEnumerable<TshirtDto> GetMatchingTshirtDto()
    {
        return GetMatchingProducts(TshirtsDto);
    }
    public IEnumerable<ShoesDto> GetMatchingShoesDto()
    {
        return GetMatchingProducts(ShoesDto);
    }
}
