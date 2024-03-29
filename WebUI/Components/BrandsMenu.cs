﻿using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class BrandsMenu : ViewComponent
    {
        private readonly IProductDtoService _productDtoService;

        public BrandsMenu(IProductDtoService productDtoService)
        {
            _productDtoService = productDtoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productDtos = await _productDtoService.GetProductsDtoAsync();

            var countByBrand = productDtos
                .GroupBy(p => p.ProductSpecificationsObjectValue.ProductBrand)
                .Select(g => new { Brand = g.Key, Count = g.Count() })
                .ToList();

            return View(countByBrand);
        }
    }
}
