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
        public async Task<IList<ProductEntity>> GetAsync() =>
        await ProductCollection.Find(_ => true).ToListAsync();

        public async Task<ProductEntity> GetLastAsync() =>
        await ProductCollection.Find(_ => true).FirstOrDefaultAsync();

        public async Task<ProductEntity> GetAsync(string id) =>
            await ProductCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<ProductEntity> GetProductNameAsync(string name) =>
            await ProductCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task<ProductEntity> CreateAsync(ProductEntity project)
        {
            await ProductCollection.InsertOneAsync(project);
            return project;
        }

        public async Task UpdateAsync(string id, ProductEntity project) =>
            await ProductCollection.ReplaceOneAsync(x => x.Id == id, project);

        public async Task RemoveAsync(ProductEntity project) =>
            await ProductCollection.DeleteOneAsync(x => x.Id == project.Id);

        #endregion
    }
}
