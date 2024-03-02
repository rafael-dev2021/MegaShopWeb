using Application.Dtos;

namespace WebUI.Areas.Admin.ViewModels.ProductViewModel;

public class ProductsFlagsViewModel
{
    public bool? IsDailyOffer { get; set; } = null;
    public bool? IsFavorite { get; set; } = null;
    public bool? IsBestSeller { get; set; } = null;

    public IEnumerable<ProductDto> ApplyProductFilters(IEnumerable<ProductDto> products)
    {
        return products
            .Where(x => (!IsDailyOffer.HasValue || x.ProductFlagsObjectValue.IsDailyOffer == IsDailyOffer)
                     && (!IsFavorite.HasValue || x.ProductFlagsObjectValue.IsFavorite == IsFavorite)
                     && (!IsBestSeller.HasValue || x.ProductFlagsObjectValue.IsBestSeller == IsBestSeller));
    }
}
