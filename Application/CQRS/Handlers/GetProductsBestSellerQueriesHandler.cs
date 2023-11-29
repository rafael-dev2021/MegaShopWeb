using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers
{
    public class GetProductsBestSellerQueriesHandler(IProductRepository productRepository) : IRequestHandler<GetProductsBestSellerQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<Product>> Handle(GetProductsBestSellerQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsBestSellersAsync();
        }
    }
}
