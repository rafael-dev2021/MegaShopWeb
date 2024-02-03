using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities.Products.Fashion.ProductShoes;
public sealed class Shoes : Product
{
    public Shoes(int id, string name, string description, List<string> images, int stock, int categoryId) : base(id, name, description,images, stock, categoryId)
    { }
    public Shoes(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        ShoesDesignOV shoesDesignObjectValue,
        ShoesGeneralFeaturesOV shoesGeneralFeaturesObjectValue,
        ShoesMaterialsOV shoesMaterialsObjectValue,
        ShoesSpecificationsOV shoesSpecificationsObjectValue,
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
        ShoesDesignObjectValue = shoesDesignObjectValue;
        ShoesGeneralFeaturesObjectValue = shoesGeneralFeaturesObjectValue;
        ShoesMaterialsObjectValue = shoesMaterialsObjectValue;
        ShoesSpecificationsObjectValue = shoesSpecificationsObjectValue;
    }
    public void ShoesUpdate(
        string name,
        string description,
        List<string> images,
        int stock, 
        ProductDataOV productDataObjectValue, 
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue, 
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue, 
        ShoesDesignOV shoesDesignObjectValue, 
        ShoesGeneralFeaturesOV shoesGeneralFeaturesObjectValue,
        ShoesMaterialsOV shoesMaterialsObjectValue, 
        ShoesSpecificationsOV shoesSpecificationsObjectValue,
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

        ShoesDesignObjectValue = shoesDesignObjectValue;
        ShoesGeneralFeaturesObjectValue = shoesGeneralFeaturesObjectValue;
        ShoesMaterialsObjectValue = shoesMaterialsObjectValue;
        ShoesSpecificationsObjectValue = shoesSpecificationsObjectValue;
    }

    public ShoesDesignOV ShoesDesignObjectValue { get; private set; }
    public ShoesGeneralFeaturesOV ShoesGeneralFeaturesObjectValue { get; private set; }
    public ShoesMaterialsOV ShoesMaterialsObjectValue { get; private set; }
    public ShoesSpecificationsOV ShoesSpecificationsObjectValue { get; private set; }
}
