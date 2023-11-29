using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Fashion.Tshirts.ObjectsValue;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Tshirts
{
    public class TshirtCommand : IRequest<Tshirt>
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
        public TshirtOtherFeaturesOV TshirtOtherFeaturesObectsValue { get; set; }
        public TshirtMainFeaturesOV TshirtMainFeaturesObectsValue { get; set; }
        public int CategoryId { get; set; }
    }
}
