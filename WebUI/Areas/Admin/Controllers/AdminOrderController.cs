using Application.Dtos.OrderDtos;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using Domain.Entities.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.OrderViewModel;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminOrderController(IOrderDtoService orderDtoService) : Controller
{
    private readonly IOrderDtoService _orderDtoService = orderDtoService;

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
        try
        {
            var result = await reportFunc(minDate, maxDate);
            ViewData["minDate"] = minDate.Value;
            ViewData["maxDate"] = maxDate.Value;
            return View(result);
        }
        catch (Exception)
        {
            return View("OrderNotFound");
        }
    }

    public async Task<IActionResult> ConfirmedSalesReport(DateTime? minDate, DateTime? maxDate)
    {
        return await GenerateSalesReportAsync(_orderDtoService.FindByOrderConfirmDateDtoAsync, minDate, maxDate);
    }

    public async Task<IActionResult> DispatchedSalesReport(DateTime? minDate, DateTime? maxDate)
    {
        return await GenerateSalesReportAsync(_orderDtoService.FindByOrderDispatchedDateDtoAsync, minDate, maxDate);
    }

    public async Task<IActionResult> RequestReceivedSalesReport(DateTime? minDate, DateTime? maxDate)
    {
        return await GenerateSalesReportAsync(_orderDtoService.FindByOrderRequestReceivedDateDtoAsync, minDate, maxDate);
    }


    [HttpGet]
    public async Task<IActionResult> OrderProducts(int? id)
    {
        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId is null)
        {
            Response.StatusCode = 404;
            return View("OrderNotFound", id.Value);
        }

        var orderDetails = await _orderDtoService.GetOrdersDetailsAsync();

        AdminOrderProductViewModel adminOrderProductViewModel = new()
        {
            OrderDto = orderId,
            OrderDetails = orderDetails,
            TotalOrder = orderId.TotalOrder
        };
        return View(adminOrderProductViewModel);
    }


    [HttpGet]
    public async Task<IActionResult> Index(string filter, int page = 1, int pageSize = 10)
    {
        var orders = await _orderDtoService.GetOrdersDtoAsync();
        var result = _orderDtoService.GetPagingListOrdersDto(filter);
        if (!string.IsNullOrWhiteSpace(filter))
        {
            var filteredOrdersByFilter = _orderDtoService.GetPagingListOrdersDto(filter);
            if (!filteredOrdersByFilter.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            orders = filteredOrdersByFilter;
        }

        int totalOrders = result.Count();
        int totalPages = (int)Math.Ceiling(totalOrders / (double)pageSize);
        var paginatedOrders = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = page;
        ViewBag.Filter = filter;

        OrderViewModel orderVM = new()
        {
            OrdersDto = paginatedOrders,
            TotalOrders = totalOrders
        };
        return View(orderVM);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId == null)
        {
            Response.StatusCode = 404;
            return View("OrderNotFound", id.Value);
        }

        return View(orderId);
    }
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(OrderDto orderDto)
    {
        if (ModelState.IsValid && orderDto.DispatchedOrder <= orderDto.RequestReceived)
        {
            await _orderDtoService.UpdateOrderPropertyAsync(orderDto);
            return RedirectToAction(nameof(Index));
        }

        if (orderDto.DispatchedOrder > orderDto.RequestReceived)
        {
            ModelState.AddModelError(string.Empty, "The Dispatched Order date cannot be later than the Request Received date. Please make sure to select valid dates.");
        }

        return View(orderDto);
    }




    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) NotFound();
        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId is null)
        {
            Response.StatusCode = 404;
            return View("OrderNotFound", id.Value);
        }
        return View(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) NotFound();
        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId is null)
        {
            Response.StatusCode = 404;
            return View("OrderNotFound", id.Value);
        }
        return View(orderId);
    }

    [ValidateAntiForgeryToken]
    [HttpPost(), ActionName("DeleteConfirm")]
    public async Task<IActionResult> DeleteConfirm(int? id)
    {
        await _orderDtoService.DeleteOrder(id);
        return RedirectToAction(nameof(Index));
    }
}
