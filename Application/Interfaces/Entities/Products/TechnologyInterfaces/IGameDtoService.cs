using Application.Dtos.ProductsDto.Technology.Games;
using Application.Interfaces.Entities.Products;

namespace Application.Interfaces.Entities.TechnologyInterfaces
{
    public interface IGameDtoService : IGenericProductService<GameDto>
    {
    }
}
