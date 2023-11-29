using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class CategoryWithProductCountList : ViewComponent
    {
        private readonly ICategoryDtoService _categoryDtoService;

        public CategoryWithProductCountList(ICategoryDtoService categoryDtoService)
        {
            _categoryDtoService = categoryDtoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesWithProductCount = await _categoryDtoService.GetCategoriesWithProductCountAsync();
            return View(categoriesWithProductCount);
        }
    }
}
