using Application.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class SortByMenu : ViewComponent
    {
        private readonly IProductDtoService _productDtoService;

        public SortByMenu(IProductDtoService productDtoService)
        {
            _productDtoService = productDtoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productDtos = await _productDtoService.GetProductsDtoAsync();

            var uniqueFlags = productDtos
                .Select(p => p.ProductFlagsObjectValue) 
                .Distinct() 
                .ToList();

            return View(uniqueFlags);
        }
    }
}
