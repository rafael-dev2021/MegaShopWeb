using Application.CQRS.Queries;
using Application.Dtos;
using Application.Errors;
using Application.Services.Entities.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities;

public class ProductDtoService(IMapper mapper, IMediator mediator) : IProductDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly string _message = "An unexpected error occurred while processing the request.";


    public async Task<IEnumerable<ProductDto>> GetProductsDtoAsync()
    {
        try
        {
            var getProducts = new GetProductsQueries();
            var result = await _mediator.Send(getProducts) ??
                throw new RequestException(new RequestError
                {
                    Message = "Products not found!",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoFavoritesAsync()
    {
        try
        {
            var favoriteProducts = new GetProductsFavoritesQueries();
            var result = await _mediator.Send(favoriteProducts) ??
                throw new RequestException(new RequestError
                {
                    Message = "No favorites products found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }

    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoDailyOffersAsync()
    {
        try
        {
            var dailyOfferProducts = new GetProductsDailyOfferQueries();
            var result = await _mediator.Send(dailyOfferProducts) ??
                throw new RequestException(new RequestError
                {
                    Message = "No daily offer products found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoBestSellersAsync()
    {
        try
        {
            var bestSellerProducts = new GetProductsBestSellerQueries();
            var result = await _mediator.Send(bestSellerProducts) ??
                throw new RequestException(new RequestError
                {
                    Message = "No best seller products found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }
    public async Task<IEnumerable<ProductDto>> GetProductsDtoByCategoriesAsync(string categoryStr)
    {
        try
        {
            var getProductByIdCategory = await _mediator.Send(new GetProductByCategoryQueries(categoryStr));
            return _mapper.Map<IEnumerable<ProductDto>>(getProductByIdCategory);
        }
        catch (RequestException)
        {
            throw new RequestException(new RequestError
            {
                Message = "No existing products.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }
    public async Task<IEnumerable<ProductDto>> GetSearchProductDtoAsync(string keyword)
    {
        try
        {
            var getSearchProduct = await _mediator.Send(new GetSearchProductDtoQueries(keyword)) ??
                throw new RequestException(new RequestError
                {
                    Message = "No products were found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<IEnumerable<ProductDto>>(getSearchProduct);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }
    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        if (id == null || id <= 0)
            throw new ArgumentException("Invalid product id");

        var getProductId = new GetByIdProductQuery(id.Value);
        var result = await _mediator.Send(getProductId) ??
            throw new RequestException(new RequestError
            {
                Message = "Product id not found!",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
        return _mapper.Map<ProductDto>(result);
    }
}
