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
    public IQueryable<OrderDto> GetPagingListOrdersDto(string filter)
    {
        var ordersDto = _orderRepository.GetPagingListOrders(filter);

        if (ordersDto == null || !ordersDto.Any())
        {
            return Enumerable.Empty<OrderDto>().AsQueryable();
        }

        return _mapper.ProjectTo<OrderDto>(ordersDto.AsQueryable());
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

    public async Task<OrderDto> UpdateOrderPropertyAsync(int orderId, Action<OrderDto> updateAction)
    {
        if (updateAction == null)
            throw new ArgumentNullException(nameof(updateAction), "Update action cannot be null.");

        var existingOrder = await _orderRepository.GetByIdAsync(orderId) ??
            throw new ArgumentException($"Order with ID {orderId} not found.", nameof(orderId));
        var orderDto = _mapper.Map<OrderDto>(existingOrder);

        updateAction(orderDto);

        var updatedOrder = _mapper.Map<Order>(orderDto);
        await _orderRepository.UpdateOrder(updatedOrder);

        return orderDto;
    }


    public async Task<IEnumerable<OrderDetailDto>> GetOrdersDetailsAsync()
    {
        var ordersDto = await _orderRepository.GetOrdersDetailsAsync();

        if (ordersDto == null || !ordersDto.Any())
        {
            return new List<OrderDetailDto>();
        }

        return _mapper.Map<IEnumerable<OrderDetailDto>>(ordersDto);
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderConfirmDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderConfirmDateAsync(minDate, maxDate);
        if (orders == null || !orders.Any())
        {
            return Enumerable.Empty<OrderDto>();
        }
        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return orderDtos;
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderDispatchedDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderDispatchedDateAsync(minDate, maxDate);
        if (orders == null || !orders.Any())
        {
            return Enumerable.Empty<OrderDto>();
        }
        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return orderDtos;
    }

    public async Task<IEnumerable<OrderDto>> FindByOrderRequestReceivedDateDtoAsync(DateTime? minDate, DateTime? maxDate)
    {
        var orders = await _orderRepository.FindByOrderRequestReceivedDateAsync(minDate, maxDate);
        if (orders == null || !orders.Any())
        {
            return Enumerable.Empty<OrderDto>();
        }
        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return orderDtos;
    }

   
}
