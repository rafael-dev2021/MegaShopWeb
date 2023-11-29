using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetProductsDailyOfferQueries : IRequest<IEnumerable<Product>>
    {
    }
}
