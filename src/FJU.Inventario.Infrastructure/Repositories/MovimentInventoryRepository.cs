using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using MongoDB.Driver;

namespace FJU.Inventario.Infrastructure.Repositories
{
    public class MovementInventoryRepository : IMovementInventoryRepository
    {
        #region Properties
        private IMongoCollection<MovimentInventoryEntity> MovementInventoryCollection { get; set; }
        #endregion

        #region Constructor
        public MovementInventoryRepository(
            IMongoDatabase db)
        {
            MovementInventoryCollection = db.GetCollection<MovimentInventoryEntity>("MovementInventory");
        }
        #endregion

        #region Implementation Repository

        public async Task<MovimentInventoryEntity> CreateAsync(MovimentInventoryEntity project)
        {
            await MovementInventoryCollection.InsertOneAsync(project);
            return project;
        }

        public async Task UpdateAsync(MovimentInventoryEntity project) =>
            await MovementInventoryCollection.ReplaceOneAsync(x => x.Id == project.Id, project);

        public async Task<IList<MovimentInventoryEntity>> GetAsync() =>
            await MovementInventoryCollection.Find(_ => true).ToListAsync();

        public async Task<MovimentInventoryEntity> GetAsync(string id) =>
            await MovementInventoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task RemoveAsync(MovimentInventoryEntity project) =>
            await MovementInventoryCollection.DeleteOneAsync(x => x.Id == project.Id);

        public async Task<IList<MovimentInventoryEntity>> GetOpenedMovementInventoryAsync(string userId) =>
            await MovementInventoryCollection.Find(x => x.UserId == userId && x.IsOpened).ToListAsync();

        public async Task<IList<MovimentInventoryEntity>> GetClosedMovementInventoryAsync(string userId) =>
            await MovementInventoryCollection.Find(x => x.UserId == userId && !x.IsOpened).ToListAsync();

        public async Task<IList<MovimentInventoryEntity>> GetOpenedMovementInventoryByProductIdAsync(string productId) =>
            await MovementInventoryCollection.Find(x => x.Products.Any(x => x.ProductId == productId) && x.IsOpened).ToListAsync();

        public async Task<IList<MovimentInventoryEntity>> GetClosedMovementInventoryByProductIdAsync(string productId) =>
            await MovementInventoryCollection.Find(x => x.Products.Any(x => x.ProductId == productId) && !x.IsOpened).ToListAsync();
        #endregion
    }
}
