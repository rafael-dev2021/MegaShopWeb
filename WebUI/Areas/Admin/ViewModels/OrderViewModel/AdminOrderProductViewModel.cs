using Application.Dtos.OrderDtos;

namespace WebUI.Areas.Admin.ViewModels.OrderViewModel;

public class AdminOrderProductViewModel
{
    public OrderDto OrderDto { get; set; }
    public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    public decimal TotalOrder { get; set; }
}
