using Application.Dtos.ProductsDto.Technology.Smartphones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using Application.Services.Entities.Interfaces;

namespace WebUI.Areas.Admin.Controllers
{
    public class SmartphoneAdminController(ISmartphoneDtoService smartphoneDtoService, ICategoryDtoService categoryDtoService) : Controller
    {
        private readonly ISmartphoneDtoService _smartphoneDtoService = smartphoneDtoService ?? throw new ArgumentNullException(nameof(smartphoneDtoService));
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService ?? throw new ArgumentNullException(nameof(categoryDtoService));

        public async Task<IActionResult> Index()
        {
            return View(await _smartphoneDtoService.GetProductsDtoAsync());
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName");
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(SmartphoneDto smartphoneDto)
        {
            if (ModelState.IsValid)
            {
                await _smartphoneDtoService.AddAsync(smartphoneDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", smartphoneDto.CategoryId);
            return View(smartphoneDto);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _smartphoneDtoService.GetProductsDtoAsync() == null)
            {
                return NotFound();
            }

            var smartphoneDto = await _smartphoneDtoService.GetByIdAsync(id);
            if (smartphoneDto == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", smartphoneDto.CategoryId);
            return View(smartphoneDto);
        }
        private async Task<bool> SmartphoneDtoExists(int id)
        {
            var tst = await _smartphoneDtoService.GetProductsDtoAsync();
            return tst.Any(e => e.Id == id);
        }

        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SmartphoneDto smartphoneDto)
        {
            if (id != smartphoneDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _smartphoneDtoService.UpdateAsync(smartphoneDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SmartphoneDtoExists(smartphoneDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", smartphoneDto.CategoryId);
            return View(smartphoneDto);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) NotFound();
            var getSmartphoneId = await _smartphoneDtoService.GetByIdAsync(id);

            if (getSmartphoneId == null) NotFound();
            return View(getSmartphoneId);
        }


        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost(), ActionName("DeleteConfirm")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _smartphoneDtoService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
