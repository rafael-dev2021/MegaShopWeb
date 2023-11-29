using Application.CQRS.Queries.Products.Fashion.TshirtQueries;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Tshirts
{
    public class GetTshirtsQueriesHandler(ITshirtRepository tshirtRepository) : IRequestHandler<GetTshirtsQueries, IEnumerable<Tshirt>>
    {
        private readonly ITshirtRepository _tshirtRepository = tshirtRepository;

        public async Task<IEnumerable<Tshirt>> Handle(GetTshirtsQueries request, CancellationToken cancellationToken)
        {
            return await _tshirtRepository.GetProductsAsync();
        }
    }
}
