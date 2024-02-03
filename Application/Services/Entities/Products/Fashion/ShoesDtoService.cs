using Application.CQRS.Command.Products.Fashion.ProductShoes;
using Application.CQRS.Queries.Products.Fashion.ShoesQueries;
using Application.Dtos.ProductsDto.Fashion.Shoes;
using Application.Errors;
using Application.Services.Entities.Products.Interfaces.FashionInterfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Fashion;

public class ShoesDtoService(IMediator mediator, IMapper mapper) : IShoesDtoService
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ShoesDto>> GetProductsDtoAsync()
    {
        var getProducts = new GetShoesQueries();
        var result = await _mediator.Send(getProducts);

        if (result?.Any() != true)
            throw new RequestException(new RequestError
            {
                Message = "No shoes found.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });

        return _mapper.Map<IEnumerable<ShoesDto>>(result);
    }

    public async Task<ShoesDto> GetByIdAsync(int? id)
    {
        if (id <= 0 || id == null)
        {
            throw new ArgumentException("Invalid shoes id. The ID should be a positive integer greater than zero.");
        }

        try
        {
            var getShoesId = new GetByIdShoesQuery(id.Value);
            var result = await _mediator.Send(getShoesId);

            return result == null
                ? throw new RequestException(new RequestError
                {
                    Message = $"Shoes with ID '{id}' not found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                })
                : _mapper.Map<ShoesDto>(result);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while adding the Shoes.", ex);
        }
    }

    public async Task AddAsync(ShoesDto entity)
    {
        try
        {
            if (entity == null)
                throw new RequestException(new RequestError
                {
                    Message = "Invalid shoes data. Cannot add a null Shoes.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            var addShoes = _mapper.Map<CreateShoesCommand>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping ShoesDto to CreateShoesCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(addShoes);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while adding the Shoes.", ex);
        }
    }
    public async Task UpdateAsync(ShoesDto entity)
    {
        try
        {
            if (entity == null)
                throw new RequestException(new RequestError
                {
                    Message = "Invalid shoes data. Cannot update with null data.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            var updateShoes = _mapper.Map<UpdateShoesCommand>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping ShoesDto to UpdateShoesCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(updateShoes);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while updating the Shoes.", ex);
        }
    }

    public async Task DeleteAsync(int? id)
    {
        if (id <= 0 || id == null)
            throw new ArgumentException("Invalid product id. The ID should be a positive integer greater than zero.",
                nameof(id));

        try
        {
            var deleteShoes = new RemoveShoesCommand(id.Value) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping ShoesDto to RemoveShoesCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(deleteShoes);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while removing the Shoes.", ex);
        }
    }
}
