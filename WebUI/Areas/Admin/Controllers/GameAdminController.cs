using Application.Dtos.ProductsDto.Technology.Games;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using Application.Services.Entities.Interfaces;

namespace WebUI.Areas.Admin.Controllers
{
    public class GameAdminController(IGameDtoService gameDtoService, ICategoryDtoService categoryDtoService) : Controller
    {
        private readonly IGameDtoService _gameDtoService = gameDtoService ?? throw new ArgumentNullException(nameof(gameDtoService));
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService ?? throw new ArgumentNullException(nameof(categoryDtoService));
        public async Task<IActionResult> Index()
        {
            return View(await _gameDtoService.GetProductsDtoAsync());
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
        public async Task<IActionResult> Create(GameDto gameDto)
        {
            if (ModelState.IsValid)
            {
                await _gameDtoService.AddAsync(gameDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", gameDto.CategoryId);
            return View(gameDto);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _gameDtoService.GetProductsDtoAsync() == null)
            {
                return NotFound();
            }

            var gameDto = await _gameDtoService.GetByIdAsync(id);
            if (gameDto == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", gameDto.CategoryId);
            return View(gameDto);
        }
        private async Task<bool> GameDtoExists(int id)
        {
            var tst = await _gameDtoService.GetProductsDtoAsync();
            return tst.Any(e => e.Id == id);
        }

        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, GameDto gameDto)
        {
            if (id != gameDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gameDtoService.UpdateAsync(gameDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GameDtoExists(gameDto.Id))
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
            ViewData["CategoryId"] = new SelectList(await _categoryDtoService.GetCategoriesDtoAsync(), "Id", "CategoryName", gameDto.CategoryId);
            return View(gameDto);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) NotFound();
            var getGameDtoId = await _gameDtoService.GetByIdAsync(id);

            if (getGameDtoId == null) NotFound();
            return View(getGameDtoId);
        }


        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost(), ActionName("DeleteConfirm")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _gameDtoService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
