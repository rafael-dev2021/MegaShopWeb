using Application.CQRS.Queries.Products.Fashion.ShoesQueries;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.ProductShoes;

public class GetByIdShoesQueryHandler(IShoesRepository shoesRepository) : IRequestHandler<GetByIdShoesQuery, Shoes>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<Shoes> Handle(GetByIdShoesQuery request, CancellationToken cancellationToken)
    {
        return await _shoesRepository.GetByIdAsync(request.Id);
    }
}
