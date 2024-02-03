using Application.Dtos;
using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components.Technology
{
    public class SmartphonesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            var smartphonesCategory = categories.FirstOrDefault(c => c.CategoryName == "Smartphones");

            if (smartphonesCategory != null)
            {
                var smartphonesProducts = (await _productDtoService.GetProductsDtoAsync())
                    .Where(p => p.CategoryId == smartphonesCategory.Id)
                    .ToList();

                return View(smartphonesProducts);
            }
            return View(Enumerable.Empty<ProductDto>());
        }
    }
}
