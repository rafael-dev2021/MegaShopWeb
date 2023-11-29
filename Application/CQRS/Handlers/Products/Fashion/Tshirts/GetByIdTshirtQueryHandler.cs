using Application.CQRS.Queries.Products.Fashion.TshirtQueries;
using Domain.Entities.Interfaces.Products.Fashion;
using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Tshirts
{
    public class GetByIdTshirtQueryHandler(ITshirtRepository tshirtRepository) : IRequestHandler<GetByIdTshirtQuery, Tshirt>
    {
        private readonly ITshirtRepository _tshirtRepository = tshirtRepository;

        public async Task<Tshirt> Handle(GetByIdTshirtQuery request, CancellationToken cancellationToken)
        {
            return await _tshirtRepository.GetByIdAsync(request.Id);
        }
    }
}
