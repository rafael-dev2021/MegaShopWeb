using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetProductsFavoritesQueries : IRequest<IEnumerable<Product>>
    {
    }
}
