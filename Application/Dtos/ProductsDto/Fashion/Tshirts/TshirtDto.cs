using Application.Dtos.ProductsDto.Fashion.Tshirts.ObjectsValue;

namespace Application.Dtos.ProductsDto.Fashion.Tshirts
{
    public sealed class TshirtDto : ProductDto
    {
        public TshirtOtherFeaturesOVDto TshirtOtherFeaturesObectsValue { get; set; }
        public TshirtMainFeaturesOVDto TshirtMainFeaturesObectsValue { get; set; }
    }
}
