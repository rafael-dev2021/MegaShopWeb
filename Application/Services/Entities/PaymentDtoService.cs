//using Application.Dtos;
//using Application.Dtos.TechnologyDtos;
//using Application.Interfaces.Entities;
//using AutoMapper;
//using Domain.Interfaces;

//namespace Application.Services.Entities
//{
//    public class PaymentDtoService : IPaymentDtoService
//    {
//        private readonly IMapper _mapper;
//        private readonly IPaymentRepository _paymentRepository;

//        public PaymentDtoService(IMapper mapper, IPaymentRepository paymentRepository)
//        {
//            _mapper = mapper;
//            _paymentRepository = paymentRepository;
//        }
//        public async Task<IEnumerable<PaymentDto>> GetPaymentsDtoAsync()
//        {
//            var getPayments = await _paymentRepository.GetPaymentsAsync();
//            if (getPayments == null || !getPayments.Any())
//            {
//                return new List<PaymentDto>();
//            }
//            return _mapper.Map<IEnumerable<PaymentDto>>(getPayments);
//        }

//        public async Task<PaymentDto> GetByIdAsync(int? id)
//        {
//            if (id == null)
//                throw new ArgumentNullException(nameof(id), "Payment ID cannot be null.");

//            var getPaymentId = await _paymentRepository.GetByIdAsync(id);

//            if (getPaymentId == null)
//                throw new Exception($"Payment with ID {id} not found.");

//            return _mapper.Map<PaymentDto>(getPaymentId);
//        }
//    }
//}
