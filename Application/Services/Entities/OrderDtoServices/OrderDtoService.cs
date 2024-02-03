using Application.Dtos.OrderDtos;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Interfaces;
using Domain.Entities.Payments.Enums;

namespace Application.Services.Entities.OrderDtoServices;

public class OrderDtoService(IMapper mapper, IOrderRepository orderRepository) : IOrderDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<IEnumerable<OrderDto>> GetOrdersDtoAsync()
    {
        var ordersDto = await _orderRepository.GetOrdersAsync();
        if (ordersDto == null || !ordersDto.Any())
        {
            return new List<OrderDto>();
        }
        return _mapper.Map<IEnumerable<OrderDto>>(ordersDto);
    }

    public async Task<OrderDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), "Order ID cannot be null.");

        var getOrderId = await _orderRepository.GetByIdAsync(id);

        return getOrderId == null ?
            throw new Exception($"Order with ID {id} not found.") :
            _mapper.Map<OrderDto>(getOrderId);
    }

    public async Task AddOrder(OrderDto orderDto, EPaymentMethod ePaymentMethod)
    {
        if (orderDto == null)
            throw new ArgumentNullException(nameof(orderDto), "OrderDto cannot be null.");

        var addOrder = _mapper.Map<Order>(orderDto);
        await _orderRepository.CreateOrder(addOrder, ePaymentMethod);
    }

    public async Task DeleteOrder(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), "Order ID cannot be null.");

        var deleteOrder = await _orderRepository.GetByIdAsync(id) ??
            throw new Exception($"Order with ID {id} not found.");
        await _orderRepository.RemoveOrder(deleteOrder);
    }

    public async Task UpdateOrder(OrderDto orderDto)
    {
        if (orderDto == null)
            throw new ArgumentNullException(nameof(orderDto), "OrderDto cannot be null.");

        var updateOrder = _mapper.Map<Order>(orderDto);
        await _orderRepository.UpdateOrder(updateOrder);
    }
}
