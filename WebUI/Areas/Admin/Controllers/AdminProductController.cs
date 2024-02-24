using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminProductController(IProductDtoService productDtoService) : Controller
{
    private readonly IProductDtoService _productDtoService = productDtoService;

    public async Task<IActionResult> Index(bool? isDailyOffer = null, bool? isBestSeller = null, bool? isFavorite = null)
    {
        var products = await _productDtoService.GetProductsDtoAsync();

        if (isDailyOffer.HasValue)
        {
            products = products.Where(p => p.ProductFlagsObjectValue.IsDailyOffer == isDailyOffer);
        }

        if (isBestSeller.HasValue)
        {
            products = products.Where(p => p.ProductFlagsObjectValue.IsBestSeller == isBestSeller);
        }
        if (isFavorite.HasValue)
        {
            products = products.Where(p => p.ProductFlagsObjectValue.IsFavorite == isFavorite);
        }
        return View(products);
    }
}
