using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones;

public class UpdateSmartphoneHandler(ISmartphoneRepository smartphoneRepository) : IRequestHandler<UpdateSmartphoneCommand, Smartphone>
{
    private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository;

    public async Task<Smartphone> Handle(UpdateSmartphoneCommand request, CancellationToken cancellationToken)
    {
        var product = await _smartphoneRepository.GetByIdAsync(request.Id);
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
            product.SmartphoneUpdate(request.Name, request.Description, request.Images, request.Stock, request.ProductDataObjectValue,
            request.ProductFlagsObjectValue, request.ProductPriceObjectValue,
            request.ProductSpecificationsObjectValue, request.ProductWarrantyObjectValue, request.SmartphoneFeatureObjectValue,
            request.SmartphoneDisplayObjectValue, request.SmartphoneMemoryObjectValue, request.SmartphoneCameraObjectValue,
            request.SmartphonePlatformObjectValue, request.SmartphoneBatteryObjectValue,
            request.SmartphoneDimensionsObjectValue, request.CategoryId);

            return await _smartphoneRepository.UpdateAsync(product);
        }
    }
}
