using Application.Dtos.OrderDtos;
using Domain.Entities.Payments.Enums;

namespace Application.Services.Entities.OrderDtoServices.Interfaces;

public interface IOrderDtoService
{
    Task<IEnumerable<OrderDto>> GetOrdersDtoAsync();
    Task<OrderDto> GetByIdAsync(int? id);
    Task AddOrder(OrderDto orderDto, EPaymentMethod ePaymentMethod);
    Task UpdateOrder(OrderDto orderDto);
    Task DeleteOrder(int? id);
}
