using Application.CQRS.Command.Products.Fashion.Shoe;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Shoes;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.Shoe
{
    public class CreateShoesHandle(IShoesRepository shoesRepository) : IRequestHandler<CreateShoesCommand, Shoes>
    {
        private readonly IShoesRepository _shoesRepository = shoesRepository;
        public async Task<Shoes> Handle(CreateShoesCommand request, CancellationToken cancellationToken)
        {
            var product = new Shoes(request.Name, request.Description, request.Stock, request.DeliveryDays, request.ProductDataObjectValue,
               request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
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
}
