using Application.CQRS.Command.Products.Technology.Games;
using Application.CQRS.Queries.Products.Technology.Games;
using Application.Dtos.ProductsDto.Technology.Games;
using Application.Errors;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Technology;

public class GameDtoService(IMapper mapper, IMediator mediator) : IGameDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    public async Task<IEnumerable<GameDto>> GetProductsDtoAsync()
    {
        var getProducts = new GetGamesQueries();
        var result = await _mediator.Send(getProducts) ??
            throw new RequestException(new RequestError
            {
                Message = "No games found.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
        return _mapper.Map<IEnumerable<GameDto>>(result) ?? Enumerable.Empty<GameDto>();
    }


    public async Task<GameDto> GetByIdAsync(int? id)
    {
        if (id <= 0 || id == null)
            throw new ArgumentException("Invalid product id. It should be a positive integer greater than zero.");

        var getGameId = new GetByIdGameQuery(id.Value);
        var result = await _mediator.Send(getGameId) ??
            throw new RequestException(new RequestError
            {
                Message = $"Product with ID '{id}' not found.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
        return _mapper.Map<GameDto>(result);
    }

    public async Task AddAsync(GameDto entity)
    {
        try
        {
            if (entity == null)
                throw new RequestException(new RequestError
                {
                    Message = "Invalid game data. Cannot add a null game.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            var addGame = _mapper.Map<CreateGameCommand>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping GameDto to CreateGameCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(addGame);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while adding the game.", ex);
        }
    }

    public async Task UpdateAsync(GameDto entity)
    {
        try
        {
            if (entity == null)
                throw new RequestException(new RequestError
                {
                    Message = "Invalid game data. Cannot update with null data.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            var updateGame = _mapper.Map<UpdateGameCommand>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping GameDto to UpdateGameCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(updateGame);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while updating the game.", ex);
        }
    }
    public async Task DeleteAsync(int? id)
    {
        if (id <= 0 || id == null)
            throw new ArgumentException("Invalid game id. The ID should be a positive integer greater than zero.",
                nameof(id));

        try
        {
            var deleteGame = new RemoveGameCommand(id.Value) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping GameDto to RemoveGameCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(deleteGame);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while deleting the game.", ex);
        }
    }
}
