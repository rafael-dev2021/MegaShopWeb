using Application.Dtos.PaymentsDto;

namespace Application.Interfaces.Entities.PaymentDtoServices;

public interface IPaymentDtoService
{
    Task<IEnumerable<PaymentDto>> GetPaymentsDtoAsync();
    Task<PaymentDto> GetByIdAsync(int? id);
}
