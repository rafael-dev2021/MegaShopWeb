using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Services.Entities.Interfaces;
using Application.Services.Entities.Products.Interfaces.FashionInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminShoesController(
    IShoesDtoService shoesDtoService,
    ICategoryDtoService categoryDtoService) : Controller
{
    private readonly IShoesDtoService _shoesDtoService = shoesDtoService;
    private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

    public async Task<IActionResult> Index()
    {
        return View(await _shoesDtoService.GetProductsDtoAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName");
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Create(ShoesDto shoesDto)
    {
        if (ModelState.IsValid)
        {
            await _shoesDtoService.AddAsync(shoesDto);
            return RedirectToAction("Index");
        }
        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", shoesDto.CategoryId);
        return View(shoesDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || await _shoesDtoService.GetProductsDtoAsync() == null) return NotFound();

        var shoesDto = await _shoesDtoService.GetByIdAsync(id);
        if (shoesDto == null) return NotFound();

        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", shoesDto.CategoryId);
        return View(shoesDto);
    }
    private async Task<bool> ShoesDtoExists(int id)
    {
        var tst = await _shoesDtoService.GetProductsDtoAsync();
        return tst.Any(e => e.Id == id);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(int id, ShoesDto shoesDto)
    {
        if (id != shoesDto.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _shoesDtoService.UpdateAsync(shoesDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ShoesDtoExists(shoesDto.Id)) return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", shoesDto.CategoryId);
        return View(shoesDto);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) NotFound();
        var shoesId = await _shoesDtoService.GetByIdAsync(id);

        if (shoesId == null) NotFound();
        return View(shoesId);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) NotFound();
        var shoesId = await _shoesDtoService.GetByIdAsync(id);

        if (shoesId == null) NotFound();
        return View(shoesId);
    }


    [ValidateAntiForgeryToken]
    [HttpPost(), ActionName("DeleteConfirm")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        await _shoesDtoService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
