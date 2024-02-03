using Application.CQRS.Command.Products.Fashion.ProductShoes;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.ProductShoes;

public class CreateShoesHandle(IShoesRepository shoesRepository) : IRequestHandler<CreateShoesCommand, Shoes>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<Shoes> Handle(CreateShoesCommand request, CancellationToken cancellationToken)
    {
        var product = new Shoes(request.Name, request.Description, request.Images, request.Stock, request.ProductDataObjectValue,
           request.ProductFlagsObjectValue, request.ProductPriceObjectValue,
           request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.ShoesDesignObjectValue,
           request.ShoesGeneralFeaturesObjectValue, request.ShoesMaterialsObjectValue, request.ShoesSpecificationsObjectValue, request.CategoryId)
           ?? throw new RequestException(new RequestError
           {
               Message = "Something went wrong",
               Severity = "error",
               StatusCode = HttpStatusCode.NotFound
           });

        product.CategoryId = request.CategoryId;
        return await _shoesRepository.CreateAsync(product);
    }
}
