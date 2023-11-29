using Application.CQRS.Command.Products.Fashion.Tshirts;
using Application.CQRS.Queries.Products.Fashion.TshirtQueries;
using Application.Dtos.ProductsDto.Fashion.Tshirts;
using Application.Errors;
using Application.Interfaces.Entities.Products.FashionInterfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Fashion
{
    public class TshirtDtoService(IMediator mediator, IMapper mapper) : ITshirtDtoService
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        public async Task AddAsync(TshirtDto entity)
        {
            try
            {
                if (entity == null)
                    throw new RequestException(new RequestError
                    {
                        Message = "Invalid tshirt data. Cannot add a null tshirt.",
                        Severity = "Error",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    });

                var addTshirt = _mapper.Map<CreateTshirtCommand>(entity);

                if (addTshirt == null)
                    throw new RequestException(new RequestError
                    {
                        Message = "Error when mapping TshirtDto to CreateTshirtCommand.",
                        Severity = "Error",
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    });

                await _mediator.Send(addTshirt);
            }
            catch (RequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred while adding the tshirt.", ex);
            }
        }

        public async Task DeleteAsync(int? id)
        {
            if (id <= 0 || id == null)
                throw new Exception("Invalid product id.");
            var deleteTshirt = new RemoveTshirtCommand(id.Value);

            var result = await _mediator.Send(deleteTshirt);
            if (result == null)
                throw new Exception("Product not found.");
        }

        public async Task<TshirtDto> GetByIdAsync(int? id)
        {
            if (id <= 0 || id == null)
                throw new ArgumentException("Invalid product id. It should be a positive integer greater than zero.");

            var getTshirtId = new GetByIdTshirtQuery(id.Value);
            var result = await _mediator.Send(getTshirtId);

            if (result == null)
                throw new RequestException(new RequestError
                {
                    Message = $"Product with ID '{id}' not found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<TshirtDto>(result); ;
        }

        public async Task<IEnumerable<TshirtDto>> GetProductsDtoAsync()
        {
            var getProducts = new GetTshirtsQueries();
            var result = await _mediator.Send(getProducts);

            if (result == null)
                throw new RequestException(new RequestError
                {
                    Message = "No tshirt found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            return _mapper.Map<IEnumerable<TshirtDto>>(result) ?? Enumerable.Empty<TshirtDto>();
        }

        public async Task UpdateAsync(TshirtDto entity)
        {
            try
            {
                if (entity == null)
                    throw new RequestException(new RequestError
                    {
                        Message = "Invalid tshirt data. Cannot update with null tshirt.",
                        Severity = "Error",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    });

                var updateTshirt = _mapper.Map<UpdateTshirtCommand>(entity);

                if (updateTshirt == null)
                    throw new RequestException(new RequestError
                    {
                        Message = "Error when mapping TshirtDto to UpdateTshirtCommand.",
                        Severity = "Error",
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    });

                await _mediator.Send(updateTshirt);
            }
            catch (RequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred while updating the tshirt.", ex);
            }
        }
    }
}
