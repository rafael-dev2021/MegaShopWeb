using Domain.Entities.Products.Technology.Smartphones;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Smartphones
{
    public class RemoveSmartphoneCommand(int id) : IRequest<Smartphone>
    {
        public int Id { get; set; } = id;
    }
}
