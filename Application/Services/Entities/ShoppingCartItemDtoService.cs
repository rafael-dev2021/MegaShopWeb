//using Application.Dtos;
//using Application.Interfaces.Entities;
//using AutoMapper;
//using Domain.Entities;
//using Domain.Interfaces;

//namespace Application.Services.Entities
//{
//    public class ShoppingCartItemDtoService : IShoppingCartItemDtoService
//    {
//        private readonly IShoppingCartItemRepository _repository;
//        private readonly IMapper _mapper;

//        public ShoppingCartItemDtoService(IShoppingCartItemRepository repository, IMapper mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsDtoAsync()
//        {
//            var products = await _repository.GetShoppingCartItemsAsync();
//            if (products == null || !products.Any())
//            {
//                return new List<ShoppingCartItemDto>();
//            }

//            return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(products);
//        }

//        public async Task GetTotalValueCartServiceAsync()
//        {
//            await _repository.GetTotalValueCartAsync();
//        }

//        public async Task GetTotalCartItemsServiceAsync()
//        {
//            await _repository.GetTotalCartItemsAsync();
//        }

//        public async Task RemoveItemServiceAsync(ProductDto productDto)
//        {
//            if (productDto == null)
//                throw new ArgumentNullException(nameof(productDto), "ProductDto cannot be null.");

//            var product = _mapper.Map<Product>(productDto);

//            if (product == null)
//                throw new Exception("Error removing product.");

//            await _repository.RemoveItemAsync(product);
//        }

//        public async Task AddCartItemAsync(ProductDto productDto, CategoryDto categoryDto)
//        {
//            if (productDto == null)
//                throw new ArgumentNullException(nameof(productDto), "ProductDto cannot be null.");

//            if (categoryDto == null)
//                throw new ArgumentNullException(nameof(categoryDto), "CategoryDto cannot be null.");

//            var addProduct = _mapper.Map<Product>(productDto);
//            var addCategory = _mapper.Map<Category>(categoryDto);

//            if (addProduct == null)
//                throw new Exception("Error adding product to cart.");

//            await _repository.CreateCartAsync(addProduct, addCategory);
//        }

//        public async Task RemoveItemCartServiceAsync(ProductDto productDto, CategoryDto categoryDto)
//        {
//            if (productDto == null)
//                throw new ArgumentNullException(nameof(productDto), "ProductDto cannot be null.");

//            if (categoryDto == null)
//                throw new ArgumentNullException(nameof(categoryDto), "CategoryDto cannot be null.");

//            var removeProduct = _mapper.Map<Product>(productDto);
//            var removeCategory = _mapper.Map<Category>(categoryDto);

//            if (removeProduct == null)
//                throw new Exception("Error removing product.");

//            await _repository.RemoveItemCartAsync(removeProduct, removeCategory);
//        }

//        public async Task ClearShoppingCartServiceAsync()
//        {
//            try
//            {
//                await _repository.ClearShoppingCartAsync();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error clearing the shopping cart.", ex);
//            }
//        }
//    }
//}
