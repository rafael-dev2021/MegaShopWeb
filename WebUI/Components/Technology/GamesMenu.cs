using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Components.Technology
{
    public class GamesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            var products = await _productDtoService.GetProductsDtoAsync();

            foreach (var item in categories)
            {
                if (item.CategoryName == "Games")
                {
                    return View(products);
                }
            }

            return View(products);
        }
    }
}
