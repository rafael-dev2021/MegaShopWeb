using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Entities
{
    public interface ICategoryDtoService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesDtoAsync();
        Task<CategoryDto> GetByIdAsync(int? id);
        Task AddAsync(CategoryDto categoryDto);
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int? id);
        Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync();
    }
}
