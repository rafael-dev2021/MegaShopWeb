using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class SmartphonesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryDtoService.GetCategoriesDtoAsync();
            var products = await _productDtoService.GetProductsDtoAsync();

            foreach (var item in categories)
            {
                if (item.CategoryName == "Smartphones")
                {
                    return View(products);
                }
            }
            return View(products);
        }
    }
}
