using Domain.Entities.Cart;
using Domain.Entities.Reviews;
using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public List<string> Images { get; protected set; } = [];
    public int Stock { get; set; }
    public byte[] RowVersion { get; set; }
    public ProductDataOV ProductDataObjectValue { get; protected set; }
    public ProductFlagsOV ProductFlagsObjectValue { get; protected set; }
    public ProductPriceOV ProductPriceObjectValue { get; protected set; }
    public ProductSpecificationsOV ProductSpecificationsObjectValue { get; protected set; }
    public ProductWarrantyOV ProductWarrantyObjectValue { get; protected set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Review> Reviews { get; set; } = [];
    public Product()
    { }
    public Product(int id, string name, string description, List<string> images, int stock, int categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Images = images;
        Stock = stock;
        CategoryId = categoryId;
    }

    public Product(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        int categoryId)
    {
        Name = name;
        Description = description;
        Images = images;
        Stock = stock;
        ProductDataObjectValue = productDataObjectValue;
        ProductFlagsObjectValue = productFlagsObjectValue;
        ProductPriceObjectValue = productPriceObjectValue;
        ProductSpecificationsObjectValue = productSpecificationsObjectValue;
        ProductWarrantyObjectValue = productWarrantyObjectValue;
        CategoryId = categoryId;
    }

    public void ProductUpdate(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        int categoryId)
    {
        Name = name;
        Description = description;
        Images = images;
        Stock = stock;
        ProductDataObjectValue = productDataObjectValue;
        ProductFlagsObjectValue = productFlagsObjectValue;
        ProductPriceObjectValue = productPriceObjectValue;
        ProductSpecificationsObjectValue = productSpecificationsObjectValue;
        ProductWarrantyObjectValue = productWarrantyObjectValue;
        CategoryId = categoryId;
    }
}
