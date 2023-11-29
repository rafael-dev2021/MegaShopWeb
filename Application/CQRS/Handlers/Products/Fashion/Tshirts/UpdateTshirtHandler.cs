using Application.CQRS.Command.Products.Fashion.Tshirts;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.Tshirts
{
    public class UpdateTshirtHandler(ITshirtRepository tshirtRepository) : IRequestHandler<UpdateTshirtCommand, Tshirt>
    {
        private readonly ITshirtRepository _tshirtRepository = tshirtRepository;
        public async Task<Tshirt> Handle(UpdateTshirtCommand request, CancellationToken cancellationToken)
        {
            var product = await _tshirtRepository.GetByIdAsync(request.Id);
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
                product.TshirtUpdate(request.Name, request.Description, request.Stock, request.DeliveryDays, request.ProductDataObjectValue,
                request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
                request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.TshirtOtherFeaturesObectsValue,
                request.TshirtMainFeaturesObectsValue, request.CategoryId);

                return await _tshirtRepository.UpdateAsync(product);
            }
        }
    }
}
