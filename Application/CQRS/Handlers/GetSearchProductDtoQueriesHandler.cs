using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers
{
    public class GetSearchProductDtoQueriesHandler(IProductRepository productRepository) : IRequestHandler<GetSearchProductDtoQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<Product>> Handle(GetSearchProductDtoQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetSearchProductAsync(request.Keyword);
        }
    }
}
