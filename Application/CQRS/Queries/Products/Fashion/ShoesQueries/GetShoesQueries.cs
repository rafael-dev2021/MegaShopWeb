using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.ShoesQueries
{
    public class GetShoesQueries : IRequest<IEnumerable<Shoes>>
    {
    }
}
