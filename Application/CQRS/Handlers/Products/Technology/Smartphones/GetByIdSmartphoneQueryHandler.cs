using Application.CQRS.Queries.Products.Technology.Smartphones;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones
{
    public class GetByIdSmartphoneQueryHandler(ISmartphoneRepository smartphoneRepository) : IRequestHandler<GetByIdSmartphoneQuery, Smartphone>
    {
        private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository ?? throw new ArgumentNullException(nameof(smartphoneRepository));

        public async Task<Smartphone> Handle(GetByIdSmartphoneQuery request, CancellationToken cancellationToken)
        {
            return await _smartphoneRepository.GetByIdAsync(request.Id);
        }
    }
}
