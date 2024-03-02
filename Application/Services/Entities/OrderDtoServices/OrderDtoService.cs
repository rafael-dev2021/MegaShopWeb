using Application.Dtos;
using Application.Dtos.OrderDtos;
using Application.Errors;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Interfaces;
using Domain.Entities.Payments.Enums;
using System.Reflection;

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

        try
        {
            var getOrderId = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(getOrderId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Order with ID {id} not found.", ex);
        }

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

    public async Task UpdateOrderPropertyAsync(OrderDto orderDto)
    {
        if (orderDto == null)
        {
            throw new ArgumentNullException(nameof(orderDto), "The order cannot be null.");
        }

        try
        {
            var updateOrder = _mapper.Map<Order>(orderDto) ?? throw new RequestException(new RequestError()
            {
                Message = "Failed to map OrderDto to Order.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            });
            await _orderRepository.UpdateOrder(updateOrder);
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating order.", ex);
        }
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

    public List<SalesByMonthDto> GetSalesByMonth(IEnumerable<OrderDto> orderDtos)
    {
        var salesByMonth = orderDtos
            .GroupBy(order => new { order.ConfirmedOrder.Year, order.ConfirmedOrder.Month })
            .Select(group => new SalesByMonthDto
            {
                Year = group.Key.Year,
                Month = group.Key.Month,
                TotalSales = group.Sum(order => order.TotalOrder)
            })
            .OrderBy(group => group.Year)
            .ThenBy(group => group.Month)
            .ToList();

        return salesByMonth.Cast<SalesByMonthDto>().ToList();
    }

    public async Task<decimal> Average()
    {
        decimal totalSum = 0;
        int totalCount = 0;

        var orders = await GetOrdersDtoAsync();

        if (orders != null)
        {
            totalCount = orders.Count();

            foreach (var item in orders)
            {
                totalSum += item.TotalOrder;
            }

            if (totalCount > 0)
            {
                decimal average = totalSum / totalCount;
                return average;
            }
        }
        return 0;
    }
}
