using Application.Dtos.CartDto;
using Application.Dtos.OrderDtos;
using Application.Services.Entities.CartDtoServices.Interfaces;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using Domain.Entities.Payments.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OrderController(IOrderDtoService orderDtoService, IShoppingCartItemDtoService shoppingCart) : Controller
    {
        private readonly IOrderDtoService _orderDtoService = orderDtoService;
        private readonly IShoppingCartItemDtoService _shoppingCart = shoppingCart;

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderDto orderDto, EPaymentMethod selectedPaymentMethod)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            // Obtém os itens do carrinho de compra do cliente
            IEnumerable<ShoppingCartItemDto> items = await _shoppingCart.GetShoppingCartItemsDtoAsync();

            if (items != null)
            {
                // Calcula o total de itens e o total do pedido
                foreach (var item in items)
                {
                    if (item.Product != null)
                    {
                        totalItensPedido += item.Quantity;
                        precoTotalPedido += (item.Product.ProductPriceObjectValue.Price * item.Quantity);
                    }
                }
            }

            // Atribui os valores obtidos ao pedido
            orderDto.TotalItemsOrder = totalItensPedido;
            orderDto.TotalOrder = precoTotalPedido;

            orderDto.PaymentMethod.Amount = precoTotalPedido;
            ViewBag.TotalQuantity = totalItensPedido;

            // Valida os dados do pedido
            if (ModelState.IsValid)
            {
                // Cria o pedido e os detalhes
                await _orderDtoService.AddOrder(orderDto, selectedPaymentMethod);

                // Define mensagens ao cliente
                ViewBag.TotalPedido = await _shoppingCart.GetTotalAmountCartServiceAsync();

                // Limpa o carrinho do cliente
                await _shoppingCart.ClearShoppingCartServiceAsync();

                // Exibe a view com dados do cliente e do pedido
                return View("~/Views/Order/CheckoutDetail.cshtml", orderDto);
            }
            return View(orderDto);
        }
    }
}
