using Domain.Entities.Cart;
using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Reviews;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public int Stock { get; set; }

        [Required]
        public ProductDataOV ProductDataObjectValue { get; protected set; }
        [Required]
        public ProductFlagsOV ProductFlagsObjectValue { get; protected set; }
        [Required]
        public ProductImageOV ProductImageObjectValue { get; protected set; }
        [Required]
        public ProductPriceOV ProductPriceObjectValue { get; protected set; }
        [Required]
        public ProductSpecificationsOV ProductSpecificationsObjectValue { get; protected set; }
        [Required]
        public ProductWarrantyOV ProductWarrantyObjectValue { get; protected set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItens { get; set; }

        protected Product()
        {
        }
        protected Product(int id, string name, string description, int stock, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Stock = stock;
            CategoryId = categoryId;
        }

        protected Product(int id, string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Stock = stock;
            ProductDataObjectValue = productDataObjectValue;
            ProductFlagsObjectValue = productFlagsObjectValue;
            ProductImageObjectValue = productImageObjectValue;
            ProductPriceObjectValue = productPriceObjectValue;
            ProductSpecificationsObjectValue = productSpecificationsObjectValue;
            ProductWarrantyObjectValue = productWarrantyObjectValue;
            CategoryId = categoryId;
        }
        protected Product(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Name = name;
            Description = description;
            Stock = stock;
            ProductDataObjectValue = productDataObjectValue;
            ProductFlagsObjectValue = productFlagsObjectValue;
            ProductImageObjectValue = productImageObjectValue;
            ProductPriceObjectValue = productPriceObjectValue;
            ProductSpecificationsObjectValue = productSpecificationsObjectValue;
            ProductWarrantyObjectValue = productWarrantyObjectValue;
            CategoryId = categoryId;
        }

        protected void ProductUpdate(string name, string description, int stock, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, int categoryId)
        {
            Name = name;
            Description = description;
            Stock = stock;
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
