using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers
{
    public class GetProductByCategoryQueriesHandler(IProductRepository productRepository) : IRequestHandler<GetProductByCategoryQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<Product>> Handle(GetProductByCategoryQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByCategoriesAsync(request.CategoryStr);
        }
    }
}
