using Application.Dtos.CartDto;
using Application.Dtos.OrderDtos;
using Application.Dtos.PaymentsDto;
using Application.Services.Entities.CartDtoServices.Interfaces;
using Application.Services.Entities.OrderDtoServices.Interfaces;
using Domain.Entities.Payments.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class OrderController(IOrderDtoService orderDtoService, IShoppingCartItemDtoService shoppingCart) : Controller
    {
        private readonly IOrderDtoService _orderDtoService = orderDtoService;
        private readonly IShoppingCartItemDtoService _shoppingCart = shoppingCart;

        [HttpGet]
        public IActionResult Checkout() => View();

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderDto orderDto, EPaymentMethod selectedPaymentMethod)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            IEnumerable<ShoppingCartItemDto> items = await _shoppingCart.GetShoppingCartItemsDtoAsync();

            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item.Product != null)
                    {
                        totalItensPedido += item.Quantity;
                        precoTotalPedido += (item.Product.ProductPriceObjectValue.Price * item.Quantity);
                    }
                }
            }

            orderDto.TotalItemsOrder = totalItensPedido;
            orderDto.TotalOrder = precoTotalPedido;

            orderDto.PaymentMethod.Amount = precoTotalPedido;
            ViewBag.TotalQuantity = totalItensPedido;

            if (!string.IsNullOrEmpty(selectedPaymentMethod.ToString()))
            {
                if (selectedPaymentMethod == EPaymentMethod.CreditCard)
                {
                    orderDto.PaymentMethod.CreditCard = new CreditCardDto
                    {
                        Id = orderDto.PaymentMethod.CreditCard.Id,
                        CardNumber = orderDto.PaymentMethod.CreditCard.CardNumber,
                        CardHolderName = orderDto.PaymentMethod.CreditCard.CardHolderName,
                        CardExpirationDate = orderDto.PaymentMethod.CreditCard.CardExpirationDate,
                        CardCVV = orderDto.PaymentMethod.CreditCard.CardCVV,
                        SSN = orderDto.PaymentMethod.CreditCard.SSN
                    };

                    orderDto.PaymentMethod.SSN = orderDto.PaymentMethod.CreditCard.SSN;
                    // Clear debit card details
                    orderDto.PaymentMethod.DebitCard = null;
                }
                else if (selectedPaymentMethod == EPaymentMethod.DebitCard)
                {
                    orderDto.PaymentMethod.DebitCard = new DebitCardDto
                    {
                        Id = orderDto.PaymentMethod.DebitCard.Id,
                        CardNumber = orderDto.PaymentMethod.DebitCard.CardNumber,
                        CardHolderName = orderDto.PaymentMethod.DebitCard.CardHolderName,
                        CardExpirationDate = orderDto.PaymentMethod.DebitCard.CardExpirationDate,
                        CardCVV = orderDto.PaymentMethod.DebitCard.CardCVV,
                        SSN = orderDto.PaymentMethod.DebitCard.SSN
                    };

                    orderDto.PaymentMethod.SSN = orderDto.PaymentMethod.DebitCard.SSN;

                    // Clear credit card details
                    orderDto.PaymentMethod.CreditCard = null;
                }

                // Process the payment
                await _orderDtoService.AddOrder(orderDto, selectedPaymentMethod);

                // Clear the shopping cart
                await _shoppingCart.ClearShoppingCartServiceAsync();

                return View("~/Views/Order/CheckoutDetail.cshtml", orderDto);
            }

            return View(orderDto);
        }
    }
}
