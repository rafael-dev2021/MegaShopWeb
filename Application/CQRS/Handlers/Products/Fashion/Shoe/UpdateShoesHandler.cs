using Application.CQRS.Command.Products.Fashion.Shoe;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Shoes;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.Shoe
{
    public class UpdateShoesHandler(IShoesRepository shoesRepository) : IRequestHandler<UpdateShoesCommand, Shoes>
    {
        private readonly IShoesRepository _shoesRepository = shoesRepository;
        public async Task<Shoes> Handle(UpdateShoesCommand request, CancellationToken cancellationToken)
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
                product.ShoesUpdate(request.Name, request.Description, request.Stock, request.DeliveryDays, request.ProductDataObjectValue,
               request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
               request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.ShoesDesignObjectValue,
               request.ShoesGeneralFeaturesObjectValue, request.ShoesMaterialsObjectValue, request.ShoesSpecificationsObjectValue, request.CategoryId);

                return await _shoesRepository.UpdateAsync(product);
            }
        }
    }
}
