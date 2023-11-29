using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes.ObjectsValue;
using Domain.Entities.Products.Fashion.Tshirts.ObjectsValue;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Shoe
{
    public class ShoesCommand : IRequest<Shoes>
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
        public ShoesDesignOV ShoesDesignObjectValue { get; set; }
        public ShoesGeneralFeaturesOV ShoesGeneralFeaturesObjectValue { get; set; }
        public ShoesMaterialsOV ShoesMaterialsObjectValue { get; set; }
        public ShoesSpecificationsOV ShoesSpecificationsObjectValue { get; set; }
        public int CategoryId { get; set; }
    }
}
