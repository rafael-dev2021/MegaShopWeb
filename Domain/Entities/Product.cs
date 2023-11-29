using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Reviews;

namespace Domain.Entities
{
    public abstract class Product
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public string DeliveryDays { get; protected set; } = string.Empty;
        public int Stock { get; set; }
        public ProductDataOV ProductDataObjectValue { get; protected set; }
        public ProductFlagsOV ProductFlagsObjectValue { get; protected set; }
        public ProductImageOV ProductImageObjectValue { get; protected set; }
        public ProductPriceOV ProductPriceObjectValue { get; protected set; }
        public ProductSpecificationsOV ProductSpecificationsObjectValue { get; protected set; }
        public ProductWarrantyOV ProductWarrantyObjectValue { get; protected set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; } 
        //public ICollection<ShoppingCartItem>? ShoppingCartItens { get; set; }

        protected Product()
        {
        }
        protected Product(int id, string name, string description, string deliveryDays, int stock, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            DeliveryDays = deliveryDays;
            Stock = stock;
            CategoryId = categoryId;
        }

        protected Product(int id, string name, string description, int stock, string deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Stock = stock;
            DeliveryDays = deliveryDays;
            ProductDataObjectValue = productDataObjectValue;
            ProductFlagsObjectValue = productFlagsObjectValue;
            ProductImageObjectValue = productImageObjectValue;
            ProductPriceObjectValue = productPriceObjectValue;
            ProductSpecificationsObjectValue = productSpecificationsObjectValue;
            ProductWarrantyObjectValue = productWarrantyObjectValue;
            CategoryId = categoryId;
        }
        protected Product(string name, string description, int stock, string deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Name = name;
            Description = description;
            Stock = stock;
            DeliveryDays = deliveryDays;
            ProductDataObjectValue = productDataObjectValue;
            ProductFlagsObjectValue = productFlagsObjectValue;
            ProductImageObjectValue = productImageObjectValue;
            ProductPriceObjectValue = productPriceObjectValue;
            ProductSpecificationsObjectValue = productSpecificationsObjectValue;
            ProductWarrantyObjectValue = productWarrantyObjectValue;
            CategoryId = categoryId;
        }

        protected void ProductUpdate(string name, string description, int stock, string deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Name = name;
            Description = description;
            Stock = stock;
            DeliveryDays = deliveryDays;
            ProductDataObjectValue = productDataObjectValue;
            ProductFlagsObjectValue = productFlagsObjectValue;
            ProductImageObjectValue = productImageObjectValue;
            ProductPriceObjectValue = productPriceObjectValue;
            ProductSpecificationsObjectValue = productSpecificationsObjectValue;
            ProductWarrantyObjectValue = productWarrantyObjectValue;
            CategoryId = categoryId;
        }
    }
}
