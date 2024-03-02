using Application.Dtos;
using Application.Dtos.CartDto;

namespace Application.Services.Entities.CartDtoServices.Interfaces;

public interface IShoppingCartItemDtoService
{
    Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsDtoAsync();
    Task AddCartItemAsync(ProductDto productDto, CategoryDto categoryDto);
    Task RemoveItemCartServiceAsync(ProductDto productDto, CategoryDto categoryDto);
    Task RemoveItemServiceAsync(ProductDto productDto);
    Task<int> GetTotalCartItemsServiceAsync();
    Task<decimal> GetTotalAmountCartServiceAsync();
    Task ClearShoppingCartServiceAsync();
}
