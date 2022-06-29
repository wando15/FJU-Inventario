using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using MongoDB.Driver;

namespace FJU.Inventario.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties
        private IMongoCollection<UserEntity> UserCollection { get; set; }
        #endregion

        #region Constructor
        public UserRepository(
            IMongoDatabase db)
        {
            UserCollection = db.GetCollection<UserEntity>("Users");
        }
        #endregion

        #region Implementation Repository
        public async Task<IList<UserEntity>> GetAsync() =>
        await UserCollection.Find(_ => true).ToListAsync();

        public async Task<UserEntity> GetLastAsync() =>
        await UserCollection.Find(_ => true).FirstOrDefaultAsync();

        public async Task<UserEntity> GetAsync(string id) =>
            await UserCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<UserEntity> GetUserNameAsync(string userName) =>
            await UserCollection.Find(x => x.UserName == userName).FirstOrDefaultAsync();

        public async Task<UserEntity> CreateAsync(UserEntity entity)
        {
            await UserCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(UserEntity entity) =>
            await UserCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

        public async Task RemoveAsync(UserEntity entity)
        {
            entity.IsActive = false;
            await UserCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
        #endregion
    }
}
