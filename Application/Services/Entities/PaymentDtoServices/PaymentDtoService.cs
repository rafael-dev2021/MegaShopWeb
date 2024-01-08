using Application.Dtos.PaymentsDto;
using Application.Interfaces.Entities.PaymentDtoServices;
using AutoMapper;
using Domain.Entities.Payments.Interfaces;

namespace Application.Services.Entities.PaymentDtoServices;

public class PaymentDtoService(IMapper mapper, IPaymentRepository paymentRepository) : IPaymentDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPaymentRepository _paymentRepository = paymentRepository;

    public async Task<IEnumerable<PaymentDto>> GetPaymentsDtoAsync()
    {
        var getPayments = await _paymentRepository.GetPaymentsAsync();
        if (getPayments == null || !getPayments.Any())
        {
            return new List<PaymentDto>();
        }
        return _mapper.Map<IEnumerable<PaymentDto>>(getPayments);
    }

    public async Task<PaymentDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), "Payment ID cannot be null.");

        var getPaymentId = await _paymentRepository.GetByIdAsync(id);

        return getPaymentId == null ? throw new Exception($"Payment with ID {id} not found.") : _mapper.Map<PaymentDto>(getPaymentId);
    }
}
