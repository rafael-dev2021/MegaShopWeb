using Application.Dtos.CartDto;
using Application.Dtos;

namespace WebUI.ViewModels.Cart;

public class ShoppingCartViewModel
{
    public IEnumerable<ProductDto> ProductDtos { get; set; }
    public IEnumerable<ShoppingCartItemDto> ShoppingCartItemsDto { get; set; }
    public IEnumerable<CategoryDto> CategoriesDto { get; set; }
    public int GetCartTotalItems { get; set; }
    public decimal GetTotalAmount { get; set; }
}
