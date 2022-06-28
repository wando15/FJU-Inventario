using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.ReturnedInventory
{
    public class ReturnedInventoryCommand : IRequestHandler<ReturnedInventoryRequest, ReturnedInventoryResponse>
    {
        #region Properties
        public ILogger<ReturnedInventoryCommand> Logger { get; set; }
        public IMovementInventoryRepository MovementInventoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
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

                await VerifyProduct(moviment.ProductId, request);

                if (moviment.AmmountWithdrawal == request.AmmountReturned)
                {
                    moviment.IsOpened = false;
                    moviment.Returned = DateTime.UtcNow;
                }

                moviment.AmmountReturned = request.AmmountReturned;

                await MovementInventoryRepository.UpdateAsync(moviment.Id, moviment);

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
            var product = await ProductRepository.GetAsync(productId);

            product.Available += request.AmmountReturned;
            await ProductRepository.UpdateAsync(product.Id, product);
        }
        #endregion
    }
}
