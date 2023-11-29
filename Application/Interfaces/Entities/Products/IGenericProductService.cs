namespace Application.Interfaces.Entities.Products
{
    public interface IGenericProductService<T> where T : class
    {
        Task<IEnumerable<T>> GetProductsDtoAsync();
        Task<T> GetByIdAsync(int? id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int? id);
    }
}
