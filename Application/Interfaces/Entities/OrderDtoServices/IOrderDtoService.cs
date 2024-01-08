using Application.Dtos.OrderDtos;

namespace Application.Interfaces.Entities.OrderDtoServices;

public interface IOrderDtoService
{
    Task<IEnumerable<OrderDto>> GetOrdersDtoAsync();
    Task<IEnumerable<OrderDetailDto>> GetOrdersDetailDtoAsync();
    Task<OrderDto> GetByIdAsync(int? id);
    Task AddOrder(OrderDto orderDto);
    Task UpdateOrder(OrderDto orderDto);
    Task DeleteOrder(int? id);
}
