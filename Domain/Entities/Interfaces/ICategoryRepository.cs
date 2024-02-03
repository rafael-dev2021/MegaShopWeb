namespace Domain.Entities.Interfaces;

public interface ICategoryRepository : IGenericEntitiesRepository<Category>
{
    Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync();
}
