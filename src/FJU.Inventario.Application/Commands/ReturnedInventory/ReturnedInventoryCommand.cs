using FJU.Inventario.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.ReturnedInventory
{
    public class ReturnedInventoryCommand : IRequestHandler<ReturnedInventoryRequest, ReturnedInventoryResponse>
    {
        #region Properties
        private ILogger<ReturnedInventoryCommand> Logger { get; }
        private IMovementInventoryRepository MovementInventoryRepository { get; }
        private IProductRepository ProductRepository { get; }
        #endregion

        #region Constructor
        public ReturnedInventoryCommand(
            ILogger<ReturnedInventoryCommand> logger,
            IMovementInventoryRepository movementInventoryRepository,
            IProductRepository productRepository)
        {
            Logger = logger;
            MovementInventoryRepository = movementInventoryRepository;
            ProductRepository = productRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<ReturnedInventoryResponse> Handle(ReturnedInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var moviment = await MovementInventoryRepository.GetAsync(request.Id);

                foreach (var item in request.Products)
                {
                    var product = await ProductRepository.GetAsync(item.ProductId);

                    product.Available += item.AmmountReturned;
                    await ProductRepository.UpdateAsync(product);
                }

                foreach (var item in moviment.Products)
                {
                    var product = request.Products.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                    item.AmmountReturned = product.AmmountReturned;
                }

                if (!moviment.Products.Any(x => x.AmmountReturned < x.AmmountWithdrawal))
                {
                    moviment.IsOpened = false;
                    moviment.Returned = DateTime.UtcNow;
                }

                await MovementInventoryRepository.UpdateAsync(moviment);

                return (ReturnedInventoryResponse)true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        #endregion

        #region Methods
        private async Task VerifyProduct(string productId, ReturnedInventoryRequest request)
        {

        }
        #endregion
    }
}
