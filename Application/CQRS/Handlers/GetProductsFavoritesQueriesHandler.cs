using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers
{
    public class GetProductsFavoritesQueriesHandler(IProductRepository productRepository) : IRequestHandler<GetProductsFavoritesQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<Product>> Handle(GetProductsFavoritesQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsFavoritesAsync();
        }
    }
}
