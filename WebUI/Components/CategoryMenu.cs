using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class CategoryMenu(ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            return View(categories);
        }
    }
}
