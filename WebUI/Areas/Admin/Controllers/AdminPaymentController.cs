using Application.Services.Entities.PaymentDtoServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminPaymentController(IPaymentDtoService paymentDtoService) : Controller
{
    private readonly IPaymentDtoService _paymentDtoService = paymentDtoService ??
        throw new ArgumentNullException(nameof(paymentDtoService));

    public async Task<IActionResult> IndexPayments() =>
        View(await _paymentDtoService.ListPaymentsDtoAsync());

    public async Task<IActionResult> IndexCreditCard() =>
        View(await _paymentDtoService.ListPaymentCreditCardsDtoAsync());

    public async Task<IActionResult> IndexDebitCard() =>
        View(await _paymentDtoService.ListPaymentDebitCardsDtoAsync());

    public async Task<IActionResult> FindCreditCard(Guid? id)
    {
        if (id == null) NotFound();

        var creditCardId = await _paymentDtoService.GetByIdPaymentCreditCardDtoAsync(id);
        if (creditCardId == null) NotFound();

        return View(creditCardId);
    }

    public async Task<IActionResult> FindDebitCard(Guid? id)
    {
        if (id == null) NotFound();

        var debitCardId = await _paymentDtoService.GetByIdPaymentDebitCardDtoAsync(id);
        if (debitCardId == null) NotFound();

        return View(debitCardId);
    }
}
