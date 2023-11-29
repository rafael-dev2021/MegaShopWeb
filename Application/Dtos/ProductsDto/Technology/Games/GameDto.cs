
using Application.Dtos.ProductsDto.Technology.Games.ObjectsValue;

namespace Application.Dtos.ProductsDto.Technology.Games
{
    public sealed class GameDto : ProductDto
    {
        public GameGeneralFeaturesOVDto GameGeneralFeaturesObjectsValue { get; set; }
        public GameSpecificationsOVDto GameSpecificationsObjectsValue { get; set; }
        public GameRequirementsOVDto GameRequirementsObjectsValue { get; set; }
    }
}
