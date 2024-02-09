using Application.Dtos.OrderDtos;

namespace WebUI.ViewModels.OrderViewModel;

public class OrderProductViewModel
{
    public OrderDto OrderDto { get; set; }
    public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    public decimal TotalOrder { get; set; }
}
