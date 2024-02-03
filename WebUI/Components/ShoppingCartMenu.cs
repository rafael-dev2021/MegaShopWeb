using Application.Services.Entities.CartDtoServices.Interfaces;
using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels.Cart;

namespace WebUI.Components;

public class ShoppingCartMenu(IShoppingCartItemDtoService shoppingCartDtoService, IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
{
    private readonly IShoppingCartItemDtoService _shoppingCartDtoService = shoppingCartDtoService;
    private readonly IProductDtoService _productDtoService = productDtoService;
    private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cartVw = new ShoppingCartViewModel()
        {
            ShoppingCartItemsDto = await _shoppingCartDtoService.GetShoppingCartItemsDtoAsync(),
            CategoriesDto = await _categoryDtoService.GetCategoriesDtoAsync(),
            GetCartTotalItems = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync(),
            GetTotalAmount = await _shoppingCartDtoService.GetTotalAmountCartServiceAsync(),
            ProductDtos = await _productDtoService.GetProductsDtoAsync()
        };
        return View(cartVw);
    }
}
