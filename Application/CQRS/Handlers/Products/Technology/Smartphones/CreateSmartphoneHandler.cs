using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones
{
    public class CreateGameHandler : IRequestHandler<CreateSmartphoneCommand, Smartphone>
    {
        private readonly ISmartphoneRepository _smartphoneRepository;

        public CreateGameHandler(ISmartphoneRepository smartphoneRepository)
        {
            _smartphoneRepository = smartphoneRepository ?? throw new ArgumentNullException(nameof(smartphoneRepository));
        }

        public async Task<Smartphone> Handle(CreateSmartphoneCommand request, CancellationToken cancellationToken)
        {
            var product = new Smartphone(request.Name, request.Description, request.Stock, request.ProductDataObjectValue,
                request.ProductFlagsObjectValue, request.ProductImageObjectValue, request.ProductPriceObjectValue,
                request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.SmartphoneFeatureObjectValue,
                request.SmartphoneDisplayObjectValue, request.SmartphoneMemoryObjectValue, request.SmartphoneCameraObjectValue,
                request.SmartphonePlatformObjectValue, request.SmartphoneBatteryObjectValue,
                request.SmartphoneDimensionsObjectValue, request.CategoryId)

                ?? throw new RequestException(new RequestError
                {
                    Message = "Something went wrong",
                    Severity = "error",
                    StatusCode = HttpStatusCode.NotFound
                });

            product.CategoryId = request.CategoryId;
            return await _smartphoneRepository.CreateAsync(product);
        }
    }
}
