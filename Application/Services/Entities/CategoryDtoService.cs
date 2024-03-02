using Application.Dtos;
using Application.Errors;
using Application.Services.Entities.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Interfaces;
namespace Application.Services.Entities;
public class CategoryDtoService(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly string _message = "An unexpected error occurred while processing the request.";

    public async Task<IEnumerable<CategoryDto>> GetCategoriesDtoAsync()
    {
        var categoriesDto = await _categoryRepository.ListItemsAsync();
        if (categoriesDto == null || !categoriesDto.Any())
        {
            return new List<CategoryDto>();
        }
        return _mapper.Map<IEnumerable<CategoryDto>>(categoriesDto);
    }

    public async Task<CategoryDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id),
                "Category ID cannot be null.");

        try
        {
            var getCategoryId = await _categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
            {
                Message = $"Category with ID {id} not found.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.NotFound
            });
            return _mapper.Map<CategoryDto>(getCategoryId);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task AddAsync(CategoryDto categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException(nameof(categoryDto),
                "CategoryDto cannot be null.");
        try
        {
            var addCategoryDto = _mapper.Map<Category>(categoryDto) ?? throw new RequestException(new RequestError
            {
                Message = "Error when adding category.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });
            await _categoryRepository.CreateAsync(addCategoryDto);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task DeleteAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), 
                $"Category {id} cannot be null.");

        try
        {
            var deleteCategory = await _categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
            {
                Message = "Error when removing category.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });
            await _categoryRepository.DeleteAsync(deleteCategory);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task UpdateAsync(CategoryDto categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException(nameof(categoryDto), 
                "The category cannot be null.");

        try
        {
            var updateCategory = _mapper.Map<Category>(categoryDto) ?? 
                throw new RequestException(new RequestError
                {
                    Message = $"Error when updating the category",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await _categoryRepository.UpdateAsync(updateCategory);
        }
        catch (Exception ex)
        {
            throw new Exception(_message, ex);
        }
    }

    public async Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductCountAsync()
    {
        var categoriesWithProductCount = await _categoryRepository.GetCategoriesWithProductCountAsync();

        if (categoriesWithProductCount == null || categoriesWithProductCount.Count == 0)
        {
            return [];
        }
        return _mapper.Map<List<CategoryWithProductCountDto>>(categoriesWithProductCount);
    }
}
