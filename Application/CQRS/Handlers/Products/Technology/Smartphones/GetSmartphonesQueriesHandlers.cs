using Application.CQRS.Queries.Products.Technology.Smartphones;
using Domain.Entities.Interfaces.Products.Technology;
using Domain.Entities.Products.Technology.Smartphones;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones
{
    public class GetSmartphonesQueriesHandlers : IRequestHandler<GetSmartphonesQueries, IEnumerable<Smartphone>>
    {
        private readonly ISmartphoneRepository _smartphoneRepository;

        public GetSmartphonesQueriesHandlers(ISmartphoneRepository smartphoneRepository)
        {
            _smartphoneRepository = smartphoneRepository ?? throw new ArgumentNullException(nameof(smartphoneRepository));
        }

        public async Task<IEnumerable<Smartphone>> Handle(GetSmartphonesQueries request, CancellationToken cancellationToken)
        {
            return await _smartphoneRepository.GetProductsAsync();
        }
    }
}
