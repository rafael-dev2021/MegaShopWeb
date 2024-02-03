using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class SortByMenu(IProductDtoService productDtoService) : ViewComponent
    {
        private readonly IProductDtoService _productDtoService = productDtoService;

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
