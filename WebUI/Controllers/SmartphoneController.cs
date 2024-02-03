using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SmartphoneController(ISmartphoneDtoService smartphoneDtoService) : Controller
    {
        private readonly ISmartphoneDtoService _smartphoneDtoService = smartphoneDtoService ?? throw new ArgumentNullException(nameof(smartphoneDtoService));

        public async Task<IActionResult> Index()
        {
            return View(await _smartphoneDtoService.GetProductsDtoAsync());
        }
    }
}
