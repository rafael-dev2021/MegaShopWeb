using Application.Dtos.OrderDtos;
using Application.Services.Entities.OrderDtoServices.Interfaces;
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
        if (id is null) return NotFound();

        try
        {
            var orderId = await _orderDtoService.GetByIdAsync(id);
            var orderDetails = await _orderDtoService.GetOrdersDetailsAsync();

            AdminOrderProductViewModel adminOrderProductViewModel = new()
            {
                OrderDto = orderId,
                OrderDetails = orderDetails,
                TotalOrder = orderId.TotalOrder
            };
            return View(adminOrderProductViewModel);
        }
        catch (Exception)
        {
            Response.StatusCode = 404;
            return View("OrderNotFound", id.Value);
        }
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
        if (id == null || await _orderDtoService.GetOrdersDtoAsync() == null)
            return BadRequest();

        var orderId = await _orderDtoService.GetByIdAsync(id);
        if (orderId.Id != id)
            return BadRequest();

        return View(orderId);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(int? id, OrderDto orderDto)
    {
        if (id != orderDto.Id)
            return BadRequest();

        if (ModelState.IsValid)
        {
            await _orderDtoService.UpdateOrderPropertyAsync(orderDto.Id, updatedOrder =>
            {
                updatedOrder.DispatchedOrder = orderDto.DispatchedOrder;
                updatedOrder.RequestReceived = orderDto.RequestReceived;
            });

            return RedirectToAction(nameof(Index));
        }

        return View(orderDto);
    }


    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) NotFound();
        var orderId = await _orderDtoService.GetByIdAsync(id);

        if (orderId == null) NotFound();
        return View(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) NotFound();
        var orderId = await _orderDtoService.GetByIdAsync(id);

        if (orderId == null) NotFound();
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
