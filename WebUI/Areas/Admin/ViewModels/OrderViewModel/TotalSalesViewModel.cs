﻿using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;

namespace WebUI.Areas.Admin.ViewModels.OrderViewModel;

public class TotalSalesViewModel
{
    public List<SalesByMonthDto> SalesByMonthDtos { get; set; }
    public IEnumerable<OrderDto> OrderDtos { get; set; }
    public IEnumerable<OrderDetailDto> OrderDetailDtos { get; set; }
    public IEnumerable<PaymentDto> PaymentDtos { get; set; }
    public decimal Average { get; set; }
    public decimal TotalOrderAmount { get; set; }
    public int TotalCountOrder { get; set; } = 0;
}
