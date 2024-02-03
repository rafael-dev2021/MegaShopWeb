using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.CQRS.Queries.Products.Technology.Smartphones;
using Application.Dtos.ProductsDto.Technology.Smartphones;
using Application.Errors;
using Application.Services.Entities.Products.Interfaces.TechnologyInterfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Technology;

public class SmartphoneDtoService(IMediator mediator, IMapper mapper) : ISmartphoneDtoService
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<SmartphoneDto>> GetProductsDtoAsync()
    {
        var getProducts = new GetSmartphonesQueries();
        var result = await _mediator.Send(getProducts);

        if (result?.Any() != true)
        {
            throw new RequestException(new RequestError
            {
                Message = "No smartphones found.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
        }

        return _mapper.Map<IEnumerable<SmartphoneDto>>(result);
    }


    public async Task<SmartphoneDto> GetByIdAsync(int? id)
    {
        if (id <= 0 || id == null)
        {
            throw new ArgumentException("Invalid smartphone id. The ID should be a positive integer greater than zero.");
        }

        try
        {
            var getSmartphoneId = new GetByIdSmartphoneQuery(id.Value);
            var result = await _mediator.Send(getSmartphoneId) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Smartphone with ID '{id}' not found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<SmartphoneDto>(result);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while fetching the smartphone by ID.", ex);
        }
    }


    public async Task AddAsync(SmartphoneDto entity)
    {
        try
        {
            if (entity == null)
            {
                throw new RequestException(new RequestError
                {
                    Message = "Invalid smartphone data. Cannot add with null data.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }

            var addSmartphone = _mapper.Map<CreateSmartphoneCommand>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping SmartphoneDto to CreateSmartphoneCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(addSmartphone);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while adding the smartphone.", ex);
        }
    }

    public async Task UpdateAsync(SmartphoneDto entity)
    {
        try
        {
            if (entity == null)
                throw new RequestException(new RequestError
                {
                    Message = "Invalid smartphone data. Cannot update with null data.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });

            var updateSmartphone = _mapper.Map<UpdateSmartphoneCommand>(entity) ?? 
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping SmartphoneDto to UpdateSmartphoneCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(updateSmartphone);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while updating the smartphone.", ex);
        }
    }
    public async Task DeleteAsync(int? id)
    {
        if (id <= 0 || id == null)
            throw new ArgumentException("Invalid product id. The ID should be a positive integer greater than zero.",
                nameof(id));

        try
        {
            var deleteSmartphone = new RemoveSmartphoneCommand(id.Value) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when mapping SmartphoneDto to RemoveSmartphoneCommand.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                });
            await _mediator.Send(deleteSmartphone);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error occurred while deleting the smartphone.", ex);
        }
    }
}
