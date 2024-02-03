using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDtoService _categoryDtoService;

        public CategoryController(ICategoryDtoService categoryDtoService)
        {
            _categoryDtoService = categoryDtoService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            return View(categories);
        }
    }
}
