namespace Domain.Entities.Cart.Interfaces;

public interface IShoppingCartItemRepository
{
    Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync();
    Task AddItemToCartAsync(Product product, Category category);
    Task<int> RemoveItemToCartAsync(Product product, Category category);
    Task<int> RemoveItemAsync(Product product);
    Task<int> GetTotalCartItemsAsync();
    Task<decimal> GetTotalAmountCartAsync();
    Task ClearShoppingCartAsync();
    IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    string ShoppingCartId { get; }
}
