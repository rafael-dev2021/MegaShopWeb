namespace Application.Dtos.CartDto;

public class ShoppingCartItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public ProductDto Product{ get; set; }
    public CategoryDto Category{ get; set; }
}
