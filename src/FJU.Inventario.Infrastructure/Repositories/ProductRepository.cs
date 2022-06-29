using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using MongoDB.Driver;

namespace FJU.Inventario.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Properties
        private IMongoCollection<ProductEntity> ProductCollection { get; set; }
        #endregion

        #region Constructor
        public ProductRepository(
            IMongoDatabase db)
        {
            ProductCollection = db.GetCollection<ProductEntity>("Products");
        }
        #endregion

        #region Implementation Repository

        public async Task<ProductEntity> CreateAsync(ProductEntity entity)
        {
            await ProductCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(ProductEntity entity) =>
            await ProductCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

        public async Task<IList<ProductEntity>> GetAsync() =>
            await ProductCollection.Find(_ => true).ToListAsync();

        public async Task<ProductEntity> GetLastAsync() =>
            await ProductCollection.Find(_ => true).FirstOrDefaultAsync();

        public async Task<ProductEntity> GetAsync(string id) =>
            await ProductCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IList<ProductEntity>> GetProductByProjectIdAsync(string id) =>
            await ProductCollection.Find(x => x.ProjectId == id).ToListAsync();

        public async Task<ProductEntity> GetProductNameAsync(string name) =>
            await ProductCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task RemoveAsync(ProductEntity entity) =>
            await ProductCollection.DeleteOneAsync(x => x.Id == entity.Id);

        #endregion
    }
}
