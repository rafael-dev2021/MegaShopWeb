using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetByIdProductQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetByIdProductQuery(int id)
        {
            Id = id;
        }
    }
}
