using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<ProductEntity> GetProductNameAsync(string name);
        Task<IList<ProductEntity>> GetProductByProjectIdAsync(string id);
    }
}
