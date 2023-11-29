using Application.CQRS.Command.Products.Technology.Games;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Games;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Games
{
    public class RemoveGameHandler(IGameRepository gameRepository) : IRequestHandler<RemoveGameCommand, Game>
    {
        private readonly IGameRepository _gameRepository = gameRepository;

        public async Task<Game> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
        {
            var product = await _gameRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new RequestException(new RequestError
                {
                    Message = "Id not found!",
                    Severity = "error",
                    StatusCode = HttpStatusCode.NotFound
                });
            }
            else
            {
                var result = await _gameRepository.DeleteAsync(product);
                return result;
            }
        }
    }
}
