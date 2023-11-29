using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.TshirtQueries
{
    public class GetTshirtsQueries : IRequest<IEnumerable<Tshirt>>
    {
    }
}
