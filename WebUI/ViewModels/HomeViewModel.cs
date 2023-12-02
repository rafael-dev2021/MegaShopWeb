using Application.Dtos;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryDto> GetCategoriesDto { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public IEnumerable<ProductDto> GetProductsDto { get; set; }
        public IEnumerable<ProductDto> GetProductsDailyOffersDto { get; set; }
    }
}
