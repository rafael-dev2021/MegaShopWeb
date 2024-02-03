namespace Domain.Entities;

public sealed class Category(int id, string categoryName, string categoryImage)
{
    public int Id { get; private set; } = id;
    public string CategoryName { get; private set; } = categoryName;
    public string CategoryImage { get; private set; } = categoryImage;
    public ICollection<Product> Products { get; }
}
