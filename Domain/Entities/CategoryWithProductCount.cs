namespace Domain.Entities;

public class CategoryWithProductCount(string categoryName, int productCount)
{
    public string CategoryName { get; private set; } = categoryName;
    public int ProductCount { get; private set; } = productCount;


}
