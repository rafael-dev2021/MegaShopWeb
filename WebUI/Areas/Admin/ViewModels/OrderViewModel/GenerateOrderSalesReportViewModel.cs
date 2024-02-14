using Application.Dtos.OrderDtos;

namespace WebUI.Areas.Admin.ViewModels.OrderViewModel;

public class GenerateOrderSalesReportViewModel
{
    public IEnumerable<OrderDto> OrderDtos { get; set; }
    public DateTime MinDate { get; set; }
    public DateTime MaxDate { get; set; }
}
