using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Shoe
{
    public class RemoveShoesCommand(int id) : IRequest<Shoes>
    {
        public int Id { get; set; } = id;
    }
}
