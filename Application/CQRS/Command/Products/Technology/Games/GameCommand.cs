using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games.ObjectsValue;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Games
{
    public class GameCommand : IRequest<Game>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DeliveryDays { get; set; }
        public int Stock { get; set; }
        public ProductDataOV ProductDataObjectValue { get; set; }
        public ProductFlagsOV ProductFlagsObjectValue { get; set; }
        public ProductImageOV ProductImageObjectValue { get; set; }
        public ProductPriceOV ProductPriceObjectValue { get; set; }
        public ProductSpecificationsOV ProductSpecificationsObjectValue { get; set; }
        public ProductWarrantyOV ProductWarrantyObjectValue { get; set; }
        public GameGeneralFeaturesOV GameGeneralFeaturesObjectsValue { get; set; }
        public GameSpecificationsOV GameSpecificationsObjectsValue { get; set; }
        public GameRequirementsOV GameRequirementsObjectsValue { get; set; }
        public int CategoryId { get; set; }
    }
}
