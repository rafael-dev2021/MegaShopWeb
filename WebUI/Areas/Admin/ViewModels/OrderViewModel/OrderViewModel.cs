using Application.Dtos.OrderDtos;

namespace WebUI.Areas.Admin.ViewModels.OrderViewModel;

public class OrderViewModel
{
    public IEnumerable<OrderDto> OrdersDto { get; set; }
    public int TotalOrders { get; set; } = 0;
}
