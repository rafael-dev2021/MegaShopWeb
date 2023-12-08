using Application.Dtos;
using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components.Technology
{
    public class GamesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            var gamesCategory = categories.FirstOrDefault(c => c.CategoryName == "Games");

            if (gamesCategory != null)
            {
                var gamesProducts = (await _productDtoService.GetProductsDtoAsync())
                    .Where(p => p.CategoryId == gamesCategory.Id)
                    .ToList();

                return View(gamesProducts);
            }

            return View(Enumerable.Empty<ProductDto>()); 
        }
    }
}
