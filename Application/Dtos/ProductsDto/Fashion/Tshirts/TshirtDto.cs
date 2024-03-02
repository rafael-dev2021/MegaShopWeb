using Application.Dtos.ProductsDto.Fashion.Tshirts.Valuables;

namespace Application.Dtos.ProductsDto.Fashion.Tshirts;

public class TshirtDto : ProductDto
{
    public TshirtOtherFeaturesOVDto TshirtOtherFeaturesObectsValue { get; set; }
    public TshirtMainFeaturesOVDto TshirtMainFeaturesObectsValue { get; set; }
}
