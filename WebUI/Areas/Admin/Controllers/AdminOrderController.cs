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

    public async Task<IActionResult> OrderProducts(int? id)
    {
        if (id is null) return NotFound();
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


    public async Task<IActionResult> Index(string filter, int page = 1, int pageSize = 1)
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
}
