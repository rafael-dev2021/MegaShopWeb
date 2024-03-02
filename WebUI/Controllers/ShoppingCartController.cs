using Application.Services.Entities.CartDtoServices.Interfaces;
using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels.Cart;

namespace WebUI.Controllers;

[Authorize]
public class ShoppingCartController(IShoppingCartItemDtoService shoppingCartDtoService, IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : Controller
{
    private readonly IShoppingCartItemDtoService _shoppingCartDtoService = shoppingCartDtoService;
    private readonly IProductDtoService _productDtoService = productDtoService;
    private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

    public async Task<IActionResult> Index()
    {
        var getCartTotal = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync();
        ViewBag.TotalCartItem = getCartTotal;

        var cartVw = new ShoppingCartViewModel()
        {
            ShoppingCartItemsDto = await _shoppingCartDtoService.GetShoppingCartItemsDtoAsync(),
            CategoriesDto = await _categoryDtoService.GetCategoriesDtoAsync(),
            GetCartTotalItems = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync(),
            GetTotalAmount = await _shoppingCartDtoService.GetTotalAmountCartServiceAsync(),
            ProductDtos = await _productDtoService.GetProductsDtoAsync()
        };

        ViewBag.Total = await _shoppingCartDtoService.GetTotalAmountCartServiceAsync();
        ViewBag.TotalItems = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync();

        return View(cartVw);
    }

    public async Task<IActionResult> ItemReview()
    {

        var cartVw = new ShoppingCartViewModel()
        {
            ShoppingCartItemsDto = await _shoppingCartDtoService.GetShoppingCartItemsDtoAsync(),
            CategoriesDto = await _categoryDtoService.GetCategoriesDtoAsync(),
            GetCartTotalItems = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync(),
            GetTotalAmount = await _shoppingCartDtoService.GetTotalAmountCartServiceAsync(),
            ProductDtos = await _productDtoService.GetProductsDtoAsync()
        };

        ViewBag.Total = await _shoppingCartDtoService.GetTotalAmountCartServiceAsync();
        ViewBag.TotalItems = await _shoppingCartDtoService.GetTotalCartItemsServiceAsync();

        return View(cartVw);
    }

    public async Task<IActionResult> AddToCartItem(int? id)
    {
        var productDto = await _productDtoService.GetByIdAsync(id);
        var categoryDto = await _categoryDtoService.GetByIdAsync(productDto.CategoryId);
        if (productDto != null)
        {
            await _shoppingCartDtoService.AddCartItemAsync(productDto, categoryDto);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveToCartItem(int? id)
    {

        var productDto = await _productDtoService.GetByIdAsync(id);
        var categoryDto = await _categoryDtoService.GetByIdAsync(productDto.CategoryId);
        if (productDto != null)
        {
            await _shoppingCartDtoService.RemoveItemCartServiceAsync(productDto, categoryDto);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Remove(int? Id)
    {
        var product = await _productDtoService.GetByIdAsync(Id);
        if (product != null)
        {
            await _shoppingCartDtoService.RemoveItemServiceAsync(product);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> CleanCart()
    {
        await _shoppingCartDtoService.ClearShoppingCartServiceAsync();
        return Redirect("/");
    }
}
