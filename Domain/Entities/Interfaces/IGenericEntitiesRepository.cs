namespace Domain.Entities.Interfaces;

public interface IGenericEntitiesRepository<T> where T : class
{
    Task<IEnumerable<T>> ListItemsAsync();
    Task<T> GetByIdAsync(int? id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
