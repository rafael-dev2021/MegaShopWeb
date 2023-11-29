using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones
{
    public class RemoveSmartphoneHandler(ISmartphoneRepository smartphoneRepository) : IRequestHandler<RemoveSmartphoneCommand, Smartphone>
    {
        private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository;

        public async Task<Smartphone> Handle(RemoveSmartphoneCommand request, CancellationToken cancellationToken)
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
                var result = await _smartphoneRepository.DeleteAsync(product);
                return result;
            }
        }
    }
}
