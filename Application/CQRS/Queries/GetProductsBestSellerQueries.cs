using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetProductsBestSellerQueries : IRequest<IEnumerable<Product>>
    {
    }
}
