using Application.CQRS.Command.Products.Fashion.Tshirts;
using Application.Errors;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;
using System.Net;

namespace Application.CQRS.Handlers.Products.Fashion.Tshirts
{
    public class RemoveTshirtHandler(ITshirtRepository tshirtRepository) : IRequestHandler<RemoveTshirtCommand, Tshirt>
    {
        private readonly ITshirtRepository _tshirtRepository = tshirtRepository;
        public async Task<Tshirt> Handle(RemoveTshirtCommand request, CancellationToken cancellationToken)
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
                var result = await _tshirtRepository.DeleteAsync(product);
                return result;
            }
        }
    }
}
