using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers
{
    public class GetProductsDailyOfferQueriesHandler(IProductRepository productRepository) : IRequestHandler<GetProductsDailyOfferQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<Product>> Handle(GetProductsDailyOfferQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsDailyOffersAsync();
        }
    }
}
