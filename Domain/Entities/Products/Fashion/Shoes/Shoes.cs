using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Fashion.Shoes.ObjectsValue;

namespace Domain.Entities.Products.Fashion.Shoes
{
    public sealed class Shoes : Product
    {

        public Shoes() { }
        public Shoes(int id, string name, string description, int stock, int categoryId) : base(id, name, description, stock, categoryId)
        {
        }
        public Shoes(int id, string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, ShoesDesignOV shoesDesignObjectValue, ShoesGeneralFeaturesOV shoesGeneralFeaturesObjectValue, ShoesMaterialsOV shoesMaterialsObjectValue, ShoesSpecificationsOV shoesSpecificationsObjectValue, int categoryId)
            : base(id, name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            ShoesDesignObjectValue = shoesDesignObjectValue;
            ShoesGeneralFeaturesObjectValue = shoesGeneralFeaturesObjectValue;
            ShoesMaterialsObjectValue = shoesMaterialsObjectValue;
            ShoesSpecificationsObjectValue = shoesSpecificationsObjectValue;
        }
        public Shoes(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, ShoesDesignOV shoesDesignObjectValue, ShoesGeneralFeaturesOV shoesGeneralFeaturesObjectValue, ShoesMaterialsOV shoesMaterialsObjectValue, ShoesSpecificationsOV shoesSpecificationsObjectValue, int categoryId)
          : base(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            ShoesDesignObjectValue = shoesDesignObjectValue;
            ShoesGeneralFeaturesObjectValue = shoesGeneralFeaturesObjectValue;
            ShoesMaterialsObjectValue = shoesMaterialsObjectValue;
            ShoesSpecificationsObjectValue = shoesSpecificationsObjectValue;
        }
        public void ShoesUpdate(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, ShoesDesignOV shoesDesignObjectValue, ShoesGeneralFeaturesOV shoesGeneralFeaturesObjectValue, ShoesMaterialsOV shoesMaterialsObjectValue, ShoesSpecificationsOV shoesSpecificationsObjectValue, int categoryId)
        {
            ProductUpdate(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId);
            ShoesDesignObjectValue = shoesDesignObjectValue;
            ShoesGeneralFeaturesObjectValue = shoesGeneralFeaturesObjectValue;
            ShoesMaterialsObjectValue = shoesMaterialsObjectValue;
            ShoesSpecificationsObjectValue = shoesSpecificationsObjectValue;
        }


        public ShoesDesignOV ShoesDesignObjectValue { get; set; }
        public ShoesGeneralFeaturesOV ShoesGeneralFeaturesObjectValue { get; set; }
        public ShoesMaterialsOV ShoesMaterialsObjectValue { get; set; }
        public ShoesSpecificationsOV ShoesSpecificationsObjectValue { get; set; }
    }
}
