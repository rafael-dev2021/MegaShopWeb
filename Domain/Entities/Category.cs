namespace Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; private set; } = string.Empty;
        public string CategoryImage { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; set; } 

        public Category() { }

        public Category(int id, string categoryName, string categoryImage)
        {
            Id = id;
            CategoryName = categoryName;
            CategoryImage = categoryImage;
        }
    }
}
