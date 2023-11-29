using Domain.Entities.Products.Technology.Smartphones;
using MediatR;

namespace Application.CQRS.Queries.Products.Technology.Smartphones
{
    public class GetByIdSmartphoneQuery(int id) : IRequest<Smartphone>
    {
        public int Id { get; set; } = id;
    }
}
