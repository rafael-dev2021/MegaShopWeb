using Application.Dtos;
using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminCategoryController(ICategoryDtoService categoryDtoService) : Controller
{
    private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;
    public async Task<IActionResult> Index() => 
        View(await _categoryDtoService.GetCategoriesDtoAsync());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            await _categoryDtoService.AddAsync(categoryDto);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var categoryId = await _categoryDtoService.GetByIdAsync(id);

        if (categoryId == null) return NotFound();

        return View(categoryId);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, CategoryDto categoryDto)
    {
        if (id != categoryDto.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryDtoService.UpdateAsync(categoryDto);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDto);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var categoryId = await _categoryDtoService.GetByIdAsync(id);

        if (categoryId is null) return NotFound();
        return View(categoryId);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var categoryId = await _categoryDtoService.GetByIdAsync(id);

        if (categoryId is null) return NotFound();
        return View(categoryId);
    }

    [HttpPost(), ActionName("DeleteConfirm")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirm(int? id)
    {
        await _categoryDtoService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
