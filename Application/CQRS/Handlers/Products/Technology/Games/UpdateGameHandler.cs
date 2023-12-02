using Application.CQRS.Command.Products.Technology.Games;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Games;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Games
{
    public class UpdateGameHandler(IGameRepository gameRepository) : IRequestHandler<UpdateGameCommand, Game>
    {
        private readonly IGameRepository _gameRepository = gameRepository;

        public async Task<Game> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
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
                product.GameUpdate(request.Name, request.Description, request.Stock, request.ProductDataObjectValue,
                request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
                request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.GameGeneralFeaturesObjectsValue,
                request.GameSpecificationsObjectsValue, request.GameRequirementsObjectsValue, request.CategoryId);

                return await _gameRepository.UpdateAsync(product);
            }
        }
    }
}
