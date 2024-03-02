using Application.CQRS.Queries.Products.Fashion.ShoesQueries;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.ProductShoes;

public class GetShoesQueriesHandler(IShoesRepository shoesRepository) : IRequestHandler<GetShoesQueries, IEnumerable<Shoes>>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<IEnumerable<Shoes>> Handle(GetShoesQueries request, CancellationToken cancellationToken)
    {
        return await _shoesRepository.GetProductsAsync();
    }
}
