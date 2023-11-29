using Domain.Entities.Products.Technology.Games;
using MediatR;

namespace Application.CQRS.Queries.Products.Technology.Games
{
    public class GetGamesQueries : IRequest<IEnumerable<Game>>
    {
    }
}
