using Application.Dtos;
using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class FashionMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            var fashionCategory = categories.FirstOrDefault(x => x.CategoryName == "Fashion");

            if (fashionCategory != null)
            {
                var fashionProducts = (await _productDtoService.GetProductsDtoAsync())
                    .Where(x => x.CategoryId == fashionCategory.Id)
                    .ToList();

                return View(fashionProducts);
            }

            return View(Enumerable.Empty<ProductDto>());
        }
    }
}
