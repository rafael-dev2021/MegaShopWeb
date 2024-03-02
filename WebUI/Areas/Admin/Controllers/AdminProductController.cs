using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.ProductViewModel;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminProductController(IProductDtoService productDtoService) : Controller
{
    private readonly IProductDtoService _productDtoService = productDtoService ??
        throw new ArgumentNullException(nameof(productDtoService));

    public async Task<IActionResult> Index(ProductsFlagsViewModel flags)
    {
        var products = await _productDtoService.GetProductsDtoAsync();

        products = flags.ApplyProductFilters(products);
        return View(products);
    }
}
