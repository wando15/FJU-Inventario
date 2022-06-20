using MongoDB.Bson;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetLastAsync();

        Task<TEntity> GetAsync(string id);

        Task<TEntity> CreateAsync(TEntity newT);

        Task UpdateAsync(string id, TEntity updatedT);

        Task RemoveAsync(TEntity updatedT);
    }
}
