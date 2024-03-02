using Domain.Entities.Products.Fashion.ProductShoes;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.ProductShoes;

public class RemoveShoesCommand(int id) : IRequest<Shoes>
{
    public int Id { get; set; } = id;
}
