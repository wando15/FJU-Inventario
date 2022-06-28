using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IMovementInventoryRepository : IRepository<MovimentInventoryEntity>
    {
        Task<IList<MovimentInventoryEntity>> GetOpenedMovementInventoryAsync(string userId);
        Task<IList<MovimentInventoryEntity>> GetClosedMovementInventoryAsync(string userId);
    }
}
