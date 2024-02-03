using Application.CQRS.Command.Products.Fashion.ProductShoes;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.ProductShoes;  

public class RemoveShoesHandler(IShoesRepository shoesRepository) : IRequestHandler<RemoveShoesCommand, Shoes>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<Shoes> Handle(RemoveShoesCommand request, CancellationToken cancellationToken)
    {
        var product = await _shoesRepository.GetByIdAsync(request.Id);
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
            var result = await _shoesRepository.DeleteAsync(product);
            return result;
        }
    }
}
