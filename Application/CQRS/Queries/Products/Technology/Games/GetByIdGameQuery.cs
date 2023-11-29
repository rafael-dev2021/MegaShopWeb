using Domain.Entities.Products.Technology.Games;
using MediatR;

namespace Application.CQRS.Queries.Products.Technology.Games
{
    public class GetByIdGameQuery(int id) : IRequest<Game>
    {
        public int Id { get; set; } = id;
    }
}
