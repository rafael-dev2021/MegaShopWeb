//using Application.Dtos;
//using Application.Dtos.TechnologyDtos;
//using Application.Interfaces.Entities;
//using AutoMapper;
//using Domain.Entities;
//using Domain.Interfaces;

//namespace Application.Services.Entities
//{
//    public class OrderDtoService : IOrderDtoService
//    {
//        private readonly IMapper _mapper;
//        private readonly IOrderRepository _orderRepository;

//        public OrderDtoService(IMapper mapper, IOrderRepository orderRepository)
//        {
//            _mapper = mapper;
//            _orderRepository = orderRepository;
//        }

//        public async Task<IEnumerable<OrderDto>> GetOrdersDtoAsync()
//        {
//            var ordersDto = await _orderRepository.GetOrdersAsync();
//            if (ordersDto == null || !ordersDto.Any())
//            {
//                return new List<OrderDto>();
//            }
//            return _mapper.Map<IEnumerable<OrderDto>>(ordersDto);
//        }

//        public async Task<IEnumerable<OrderDetailDto>> GetOrdersDetailDtoAsync()
//        {
//            var orderDetails = await _orderRepository.GetOrdersDetailsAsync();
//            if (orderDetails == null || !orderDetails.Any())
//            {
//                return new List<OrderDetailDto>();
//            }
//            return _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
//        }

//        public async Task<OrderDto> GetByIdAsync(int? id)
//        {
//            if (id == null)
//                throw new ArgumentNullException(nameof(id), "Order ID cannot be null.");

//            var getOrderId = await _orderRepository.GetByIdAsync(id);

//            if (getOrderId == null)
//                throw new Exception($"Order with ID {id} not found.");

//            return _mapper.Map<OrderDto>(getOrderId);
//        }

//        public async Task AddOrder(OrderDto orderDto)
//        {
//            if (orderDto == null)
//                throw new ArgumentNullException(nameof(orderDto), "OrderDto cannot be null.");

//            var addOrder = _mapper.Map<Order>(orderDto);
//            await _orderRepository.CreateOrder(addOrder);
//        }

//        public async Task DeleteOrder(int? id)
//        {
//            if (id == null)
//                throw new ArgumentNullException(nameof(id), "Order ID cannot be null.");

//            var deleteOrder = await _orderRepository.GetByIdAsync(id);

//            if (deleteOrder == null)
//                throw new Exception($"Order with ID {id} not found.");

//            await _orderRepository.RemoveOrder(deleteOrder);
//        }

//        public async Task UpdateOrder(OrderDto orderDto)
//        {
//            if (orderDto == null)
//                throw new ArgumentNullException(nameof(orderDto), "OrderDto cannot be null.");

//            var updateOrder = _mapper.Map<Order>(orderDto);
//            await _orderRepository.UpdateOrder(updateOrder);
//        }
//    }
//}
