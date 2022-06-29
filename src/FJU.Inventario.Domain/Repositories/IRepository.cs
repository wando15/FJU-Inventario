using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IRepository<T> where T : TEntity
    {
        Task<IList<T>> GetAsync();

        Task<T> GetAsync(string id);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
