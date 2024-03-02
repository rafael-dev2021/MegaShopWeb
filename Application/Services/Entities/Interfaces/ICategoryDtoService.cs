using Application.Dtos;

namespace Application.Services.Entities.Interfaces;

public interface ICategoryDtoService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesDtoAsync();
    Task<CategoryDto> GetByIdAsync(int? id);
    Task AddAsync(CategoryDto categoryDto);
    Task UpdateAsync(CategoryDto categoryDto);
    Task DeleteAsync(int? id);
    Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductCountAsync();
}
