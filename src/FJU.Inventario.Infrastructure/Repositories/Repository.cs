using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FJU.Inventario.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        private IMongoCollection<TEntity> TCollection { get; set; }
        private MongoConfig Config { get; set; }
        private IMongoDatabase Database { get; set; }

        public Repository(
            IOptions<MongoConfig> config,
            IMongoDatabase database)
        {
            Config = config.Value;
            Database = database;
            TCollection = database.GetCollection<TEntity>(config.Value.CollectionName);
        }

        public async Task<IList<TEntity>> GetAsync() =>
            await TCollection.Find(_ => true).ToListAsync();

        public virtual Task<TEntity> GetAsync(string id) =>
            throw new NotImplementedException();

        public async Task CreateAsync(TEntity newT) =>
            await TCollection.InsertOneAsync(newT);

        public virtual Task UpdateAsync(string id, TEntity updatedT) => 
            throw new NotImplementedException();

        public virtual Task RemoveAsync(string id) =>
            throw new NotImplementedException();
    }
}
