using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminProductController(IProductDtoService productDtoService) : Controller
{
    private readonly IProductDtoService _productDtoService = productDtoService;

    public async Task<IActionResult> Index() => View(await _productDtoService.GetProductsDtoAsync());
}
