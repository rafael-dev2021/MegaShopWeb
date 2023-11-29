using Application.CQRS.Queries.Products.Technology.Games;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Games;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Games
{
    public class GetGameQueriesHandler(IGameRepository gameRepository) : IRequestHandler<GetGamesQueries, IEnumerable<Game>>
    {
        private readonly IGameRepository _gameRepository = gameRepository;

        public async Task<IEnumerable<Game>> Handle(GetGamesQueries request, CancellationToken cancellationToken)
        {
            return await _gameRepository.GetProductsAsync();
        }
    }
}
