using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class CategoryWithProductCountList(ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesWithProductCount = await _categoryDtoService.GetCategoriesWithProductCountAsync();
            return View(categoriesWithProductCount);
        }
    }
}
