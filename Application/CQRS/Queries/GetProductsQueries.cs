using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetProductsQueries : IRequest<IEnumerable<Product>>
    {
    }
}
