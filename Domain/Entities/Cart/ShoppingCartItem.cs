namespace Domain.Entities.Cart;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int Quantity { get; set; }
    public string ShoppingCartId { get; set; }
    public string UserId { get; set; }
}
