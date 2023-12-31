﻿using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Fashion.Tshirts.ObjectsValue;

namespace Domain.Entities.Products.Fashion.Tshirts
{
    public sealed class Tshirt : Product
    {
        public Tshirt() { }
        public Tshirt(int id, string name, string description, int stock, int categoryId) : base(id, name, description, stock, categoryId)
        {
        }
        public Tshirt(int id, string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, TshirtOtherFeaturesOV tshirtOtherFeaturesObectsValue, TshirtMainFeaturesOV tshirtMainFeaturesObectsValue, int categoryId)
            : base(id, name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            TshirtOtherFeaturesObectsValue = tshirtOtherFeaturesObectsValue;
            TshirtMainFeaturesObectsValue = tshirtMainFeaturesObectsValue;
        }
        public Tshirt(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, TshirtOtherFeaturesOV tshirtOtherFeaturesObectsValue, TshirtMainFeaturesOV tshirtMainFeaturesObectsValue, int categoryId)
         : base(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            TshirtOtherFeaturesObectsValue = tshirtOtherFeaturesObectsValue;
            TshirtMainFeaturesObectsValue = tshirtMainFeaturesObectsValue;
        }

        public void TshirtUpdate(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, TshirtOtherFeaturesOV tshirtOtherFeaturesObectsValue, TshirtMainFeaturesOV tshirtMainFeaturesObectsValue, int categoryId)
        {
            ProductUpdate(name, description, stock, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId);
            TshirtOtherFeaturesObectsValue = tshirtOtherFeaturesObectsValue;
            TshirtMainFeaturesObectsValue = tshirtMainFeaturesObectsValue;
        }

        public TshirtOtherFeaturesOV TshirtOtherFeaturesObectsValue { get; set; }
        public TshirtMainFeaturesOV TshirtMainFeaturesObectsValue { get; set; }
    }
}
