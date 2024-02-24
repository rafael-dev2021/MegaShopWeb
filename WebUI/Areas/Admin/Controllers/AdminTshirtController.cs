using Application.Dtos.ProductsDto.Fashion.Tshirts;
using Application.Services.Entities.Interfaces;
using Application.Services.Entities.Products.Interfaces.FashionInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminTshirtController(ITshirtDtoService tshirtDtoService, ICategoryDtoService categoryDtoService) : Controller
{
    private readonly ITshirtDtoService _tshirtDtoService = tshirtDtoService ?? throw new ArgumentNullException(nameof(tshirtDtoService));
    private readonly ICategoryDtoService _categoryDtoService = categoryDtoService ?? throw new ArgumentNullException(nameof(categoryDtoService));

    public async Task<IActionResult> Index()
    {
        return View(await _tshirtDtoService.GetProductsDtoAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName");
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Create(TshirtDto tShirtDto)
    {
        if (ModelState.IsValid)
        {
            await _tshirtDtoService.AddAsync(tShirtDto);
            return RedirectToAction("Index");
        }
        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", tShirtDto.CategoryId);
        return View(tShirtDto);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null ||
            await _tshirtDtoService.GetProductsDtoAsync() == null)
            return NotFound();

        var tShirtDto = await _tshirtDtoService.GetByIdAsync(id);
        if (tShirtDto is null) return NotFound();

        ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", tShirtDto.CategoryId);
        return View(tShirtDto);
    }

    private async Task<bool> TshirtDtoExists(int id)
    {
        var tst = await _tshirtDtoService.GetProductsDtoAsync();
        return tst.Any(e => e.Id == id);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(int id, TshirtDto tShirtDto)
    {
        if (id != tShirtDto.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _tshirtDtoService.UpdateAsync(tShirtDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TshirtDtoExists(tShirtDto.Id)) return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(
            await _categoryDtoService.GetCategoriesDtoAsync(),
            "Id", "CategoryName",
            tShirtDto.CategoryId);

        return View(tShirtDto);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) NotFound();
        var tShirtDtoId = await _tshirtDtoService.GetByIdAsync(id);

        if (tShirtDtoId == null) NotFound();
        return View(tShirtDtoId);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) NotFound();
        var tShirtDtoId = await _tshirtDtoService.GetByIdAsync(id);

        if (tShirtDtoId is null) NotFound();
        return View(tShirtDtoId);
    }


    [ValidateAntiForgeryToken]
    [HttpPost(), ActionName("DeleteConfirm")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        await _tshirtDtoService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
