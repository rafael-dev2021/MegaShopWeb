using Domain.Entities.Products.Fashion.Tshirts.Valuables;
using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities.Products.Fashion.Tshirts;

public sealed class Tshirt : Product
{
    public Tshirt(int id, string name, string description, List<string> images, int stock, int categoryId) : base(id, name, description, images, stock, categoryId)
    { }

    public Tshirt(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        TshirtOtherFeaturesOV tshirtOtherFeaturesObectsValue,
        TshirtMainFeaturesOV tshirtMainFeaturesObectsValue,
        int categoryId)
     : base(
           name,
           description,
           images,
           stock,
           productDataObjectValue,
           productFlagsObjectValue,
           productPriceObjectValue,
           productSpecificationsObjectValue,
           productWarrantyObjectValue,
           categoryId)
    {
        TshirtOtherFeaturesObectsValue = tshirtOtherFeaturesObectsValue;
        TshirtMainFeaturesObectsValue = tshirtMainFeaturesObectsValue;
    }

    public void TshirtUpdate(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        TshirtOtherFeaturesOV tshirtOtherFeaturesObectsValue,
        TshirtMainFeaturesOV tshirtMainFeaturesObectsValue,
        int categoryId)
    {
        ProductUpdate(
            name,
            description,
            images,
            stock,
            productDataObjectValue,
            productFlagsObjectValue,
            productPriceObjectValue,
            productSpecificationsObjectValue,
            productWarrantyObjectValue,
            categoryId);

        TshirtOtherFeaturesObectsValue = tshirtOtherFeaturesObectsValue;
        TshirtMainFeaturesObectsValue = tshirtMainFeaturesObectsValue;
    }
    public TshirtOtherFeaturesOV TshirtOtherFeaturesObectsValue { get; private set; }
    public TshirtMainFeaturesOV TshirtMainFeaturesObectsValue { get; private set; }
}
