using Application.CQRS.Command.Products.Fashion.Tshirts;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.Tshirts
{
    public class CreateTshirtHandler(ITshirtRepository tshirtRepository) : IRequestHandler<CreateTshirtCommand, Tshirt>
    {
        private readonly ITshirtRepository _tshirtRepository = tshirtRepository;

        public async Task<Tshirt> Handle(CreateTshirtCommand request, CancellationToken cancellationToken)
        {
            var product = new Tshirt(request.Name, request.Description, request.Stock, request.ProductDataObjectValue,
                request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
                request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.TshirtOtherFeaturesObectsValue,
                request.TshirtMainFeaturesObectsValue, request.CategoryId)
                ?? throw new RequestException(new RequestError
                {
                    Message = "Something went wrong",
                    Severity = "error",
                    StatusCode = HttpStatusCode.NotFound
                });

            product.CategoryId = request.CategoryId;
            return await _tshirtRepository.CreateAsync(product);
        }
    }
}
