using Application.CQRS.Command.Products.Technology.Games;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Games;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Games;

public class CreateGameHandler(IGameRepository gameRepository) : IRequestHandler<CreateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var product = new Game(request.Name, request.Description, request.Images, request.Stock, request.ProductDataObjectValue,
            request.ProductFlagsObjectValue, request.ProductPriceObjectValue,
            request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.GameGeneralFeaturesObjectsValue,
            request.GameSpecificationsObjectsValue, request.GameRequirementsObjectsValue, request.CategoryId)

         ?? throw new RequestException(new RequestError
         {
             Message = "Something went wrong",
             Severity = "error",
             StatusCode = HttpStatusCode.NotFound
         });

        product.SetCategoryId(request.CategoryId);
        return await _gameRepository.CreateAsync(product);
    }
}
