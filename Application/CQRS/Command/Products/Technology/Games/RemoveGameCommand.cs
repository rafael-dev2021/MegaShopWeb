using Domain.Entities.Products.Technology.Games;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Games
{
    public class RemoveGameCommand(int id) : IRequest<Game>
    {
        public int Id { get; set; } = id;
    }
}
