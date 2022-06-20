using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Domain.Repositories
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        Task<ProjectEntity> GetProjectNameAsync(string name);
    }
}
