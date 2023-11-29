namespace Domain.Entities.Interfaces.Products
{
    public interface IGenericProductsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetProductsAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
