using Application.Services.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICategoryDtoService categoryDtoService, IProductDtoService productDtoService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly ICategoryDtoService _categoryDtoService = categoryDtoService ?? throw new ArgumentNullException(nameof(categoryDtoService));
        private readonly IProductDtoService _productDtoService = productDtoService ?? throw new ArgumentNullException(nameof(productDtoService));

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getCategoriesDtoAsync = await _categoryDtoService.GetCategoriesDtoAsync();
            var getProductsDtoAsync = await _productDtoService.GetProductsDtoAsync();
            var dailyOfferProducts = await _productDtoService.GetProductsDtoDailyOffersAsync();

            var homeVw = new HomeViewModel()
            {
                GetCategoriesDto = getCategoriesDtoAsync,
                GetProductsDto = getProductsDtoAsync,
                GetProductsDailyOffersDto = dailyOfferProducts
            };


            return View(homeVw);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
