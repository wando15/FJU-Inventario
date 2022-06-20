using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetUserNameAsync(string userName);
    }
}
