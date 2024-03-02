using Application.Dtos.PaymentsDto;

namespace Application.Services.Entities.PaymentDtoServices.Interfaces;

public interface IPaymentDtoService
{
    Task<IEnumerable<PaymentMethodDto>> ListPaymentsDtoAsync();
    Task<IEnumerable<CreditCardDto>> ListPaymentCreditCardsDtoAsync();
    Task<IEnumerable<DebitCardDto>> ListPaymentDebitCardsDtoAsync();

    Task<PaymentMethodDto> GetByIdPaymentDtoAsync(int? id);
    Task<CreditCardDto> GetByIdPaymentCreditCardDtoAsync(Guid? id);
    Task<DebitCardDto> GetByIdPaymentDebitCardDtoAsync(Guid? id);
}
