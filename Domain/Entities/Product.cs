using Domain.Entities.Reviews;
using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public List<string> Images { get; protected set; } = [];
    public int Stock { get; protected set; }
    public byte[] RowVersion { get; set; } = [];
    public ProductDataOV ProductDataObjectValue { get; protected set; }
    public ProductFlagsOV ProductFlagsObjectValue { get; protected set; }
    public ProductPriceOV ProductPriceObjectValue { get; protected set; }
    public ProductSpecificationsOV ProductSpecificationsObjectValue { get; protected set; }
    public ProductWarrantyOV ProductWarrantyObjectValue { get; protected set; }
    public int CategoryId { get; protected set; }
    public Category Category { get; }
    public ICollection<Review> Reviews { get; } = [];
    public Product()
    { }
    public void SetStock(int stock) => Stock = stock;
    public void SetCategoryId(int categoryId) => CategoryId = categoryId;
    protected Product(int id, string name, string description, List<string> images, int stock, int categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Images = images;
        Stock = stock;
        CategoryId = categoryId;
    }

    protected Product(
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

    protected void ProductUpdate(
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
