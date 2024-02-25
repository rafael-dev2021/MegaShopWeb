using Application.Dtos.OrderDtos;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using Application.Services.Entities.PaymentDtoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.OrderViewModel;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminOrderController(IOrderDtoService orderDtoService, IPaymentDtoService paymentDtoService) : Controller
{
    private readonly IOrderDtoService _orderDtoService = orderDtoService ??
              throw new ArgumentNullException(nameof(orderDtoService));

    private readonly IPaymentDtoService _paymentDtoService = paymentDtoService ??
              throw new ArgumentNullException(nameof(paymentDtoService));

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await _orderDtoService.GetOrdersDtoAsync();

        int totalCountOrder = orders.Count();

        OrderViewModel orderVM = new()
        {
            OrdersDto = orders,
            TotalCountOrder = totalCountOrder
        };
        return View(orderVM);
    }

    public async Task<IActionResult> Sales()
    {
        var orders = await _orderDtoService.GetOrdersDtoAsync();
        var orderDetails = await _orderDtoService.GetOrdersDetailsAsync();
        var payments = await _paymentDtoService.ListPaymentsDtoAsync();
        var salesByMonthModel = _orderDtoService.GetSalesByMonth(orders);
        var average = await _orderDtoService.Average();
        var totalOrderAmount = orders.Sum(obj => obj.TotalOrder);
        var totalCountOrder = orders.Count();

        TotalSalesViewModel totalSalesVm = new()
        {
            OrderDtos = orders,
            OrderDetailDtos = orderDetails,
            PaymentDtos = payments,
            SalesByMonthDtos = salesByMonthModel,
            Average = average,
            TotalOrderAmount = totalOrderAmount,
            TotalCountOrder = totalCountOrder
        };

        return View(totalSalesVm);
    }


    public async Task<IActionResult> ConfirmedSalesReport(DateTime? minDate, DateTime? maxDate) =>
         await GenerateSalesReportAsync(_orderDtoService
              .FindByOrderConfirmDateDtoAsync, minDate, maxDate);

    public async Task<IActionResult> DispatchedSalesReport(DateTime? minDate, DateTime? maxDate) =>
         await GenerateSalesReportAsync(_orderDtoService
              .FindByOrderDispatchedDateDtoAsync, minDate, maxDate);

    public async Task<IActionResult> RequestReceivedSalesReport(DateTime? minDate, DateTime? maxDate) =>
         await GenerateSalesReportAsync(_orderDtoService
              .FindByOrderRequestReceivedDateDtoAsync, minDate, maxDate);


    [HttpGet]
    public async Task<IActionResult> OrderProducts(int? id)
    {
        if (!id.HasValue || !int.TryParse(id.ToString(), out int Id))
            return RedirectToAction(nameof(Index));

        var orderId = await _orderDtoService.GetByIdAsync(Id);

        if (orderId == null)
            return View("OrderNotFound", Id);

        var orderDetails = await _orderDtoService.GetOrdersDetailsAsync();

        AdminOrderProductViewModel adminOrderProductViewModel = new()
        {
            OrderDto = orderId,
            OrderDetails = orderDetails,
            TotalOrderAmount = orderId.TotalOrder
        };

        return View(adminOrderProductViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId == null)
            return View("OrderNotFound", id.Value);

        return View(orderId);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(OrderDto orderDto)
    {
        if (ModelState.IsValid && ValidateEditOrderDates(orderDto))
        {
            await _orderDtoService.UpdateOrderPropertyAsync(orderDto);
            return RedirectToAction(nameof(Index));
        }

        if (!ValidateEditOrderDates(orderDto))
        {
            ModelState.AddModelError(string.Empty,
                "The Dispatched Order date cannot be later than the Request Received date. " +
                "Please make sure to select valid dates.");
        }

        return View(orderDto);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) NotFound();

        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId == null)
            return View("OrderNotFound", id.Value);

        return View(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) NotFound();

        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId == null)
            return View("OrderNotFound", id.Value);

        return View(orderId);
    }

    [ValidateAntiForgeryToken]
    [HttpPost(), ActionName("DeleteConfirm")]
    public async Task<IActionResult> DeleteConfirm(int? id)
    {
        await _orderDtoService.DeleteOrder(id);
        return RedirectToAction(nameof(Index));
    }

    private static bool ValidateEditOrderDates(OrderDto orderDto) =>
        orderDto.DispatchedOrder <= orderDto.RequestReceived;

    private async Task<IActionResult> GenerateSalesReportAsync(
      Func<DateTime?, DateTime?, Task<IEnumerable<OrderDto>>> reportFunc,
      DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = DateTime.Now.AddMonths(-1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }
        var result = await reportFunc(minDate, maxDate);
        ViewData["minDate"] = minDate.Value;
        ViewData["maxDate"] = maxDate.Value;
        return View(result);
    }
}
