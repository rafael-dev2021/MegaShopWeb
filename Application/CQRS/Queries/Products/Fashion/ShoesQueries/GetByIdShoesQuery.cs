using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.ShoesQueries
{
    public class GetByIdShoesQuery(int id) : IRequest<Shoes>
    {
        public int Id { get; set; } = id;
    }
}
