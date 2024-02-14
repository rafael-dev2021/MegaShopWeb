﻿using Application.Dtos.OrderDtos;
using Domain.Entities.Payments.Enums;

namespace Application.Services.Entities.OrderDtoServices.Interfaces;

public interface IOrderDtoService
{
    Task<IEnumerable<OrderDto>> GetOrdersDtoAsync();
    IQueryable<OrderDto> GetPagingListOrdersDto(string filter);
    Task<IEnumerable<OrderDto>> FindByOrderConfirmDateDtoAsync(DateTime? minDate, DateTime? maxDate);
    Task<IEnumerable<OrderDto>> FindByOrderDispatchedDateDtoAsync(DateTime? minDate, DateTime? maxDate);
    Task<IEnumerable<OrderDto>> FindByOrderRequestReceivedDateDtoAsync(DateTime? minDate, DateTime? maxDate);
    Task<IEnumerable<OrderDetailDto>> GetOrdersDetailsAsync();
    Task<OrderDto> GetByIdAsync(int? id);
    Task AddOrder(OrderDto orderDto, EPaymentMethod ePaymentMethod);
    Task<OrderDto> UpdateOrderPropertyAsync(int orderId, Action<OrderDto> updateAction);
    Task DeleteOrder(int? id);
}
