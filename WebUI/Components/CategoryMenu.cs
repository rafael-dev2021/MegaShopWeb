using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryDtoService _categoryDtoService;

        public CategoryMenu(ICategoryDtoService categoryDtoService)
        {
            _categoryDtoService = categoryDtoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            return View(categories);
        }
    }
}
