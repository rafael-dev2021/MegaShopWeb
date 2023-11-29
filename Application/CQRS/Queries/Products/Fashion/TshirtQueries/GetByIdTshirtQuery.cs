using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.TshirtQueries
{
    public class GetByIdTshirtQuery(int id) : IRequest<Tshirt>
    {
        public int Id { get; set; } = id;
    }
}
