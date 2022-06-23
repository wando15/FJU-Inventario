using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using MongoDB.Driver;

namespace FJU.Inventario.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        #region Properties
        private IMongoCollection<ProjectEntity> ProjectCollection { get; set; }
        #endregion

        #region Constructor
        public ProjectRepository(
            IMongoDatabase db)
        {
            ProjectCollection = db.GetCollection<ProjectEntity>("Projects");
        }
        #endregion

        #region Implementation Repository
        public async Task<IList<ProjectEntity>> GetAsync() =>
        await ProjectCollection.Find(_ => true).ToListAsync();

        public async Task<ProjectEntity> GetLastAsync() =>
        await ProjectCollection.Find(_ => true).FirstOrDefaultAsync();

        public async Task<ProjectEntity> GetAsync(string id) =>
            await ProjectCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<ProjectEntity> GetProjectNameAsync(string name) =>
            await ProjectCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task<ProjectEntity> CreateAsync(ProjectEntity project)
        {
            await ProjectCollection.InsertOneAsync(project);
            return project;
        }

        public async Task UpdateAsync(string id, ProjectEntity project) =>
            await ProjectCollection.ReplaceOneAsync(x => x.Id == id, project);

        public async Task RemoveAsync(ProjectEntity project) =>
            await ProjectCollection.DeleteOneAsync(x => x.Id == project.Id);

        #endregion
    }
}
