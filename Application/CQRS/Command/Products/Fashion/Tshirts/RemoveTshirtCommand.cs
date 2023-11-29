using Domain.Entities.Products.Fashion.Tshirts;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Tshirts
{
    public class RemoveTshirtCommand(int id) : IRequest<Tshirt>
    {
        public int Id { get; set; } = id;
    }
}
