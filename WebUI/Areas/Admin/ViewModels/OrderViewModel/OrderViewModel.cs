using Application.Dtos.OrderDtos;

namespace WebUI.Areas.Admin.ViewModels.OrderViewModel;

public class OrderViewModel
{
    public IEnumerable<OrderDto> OrdersDto { get; set; }
    public OrderDto OrderDto { get; set; } = new OrderDto();
    public int TotalCountOrder { get; set; } = 0;
}
