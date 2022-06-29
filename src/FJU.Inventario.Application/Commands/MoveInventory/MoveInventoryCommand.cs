using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.MoveInventory
{
    public class MoveInventoryCommand : IRequestHandler<MoveInventoryRequest, MoveInventoryResponse>
    {
        #region Properties
        private ILogger<MoveInventoryCommand> Logger { get; }
        private IMovementInventoryRepository MovementInventoryRepository { get; }
        private IProductRepository ProductRepository { get; }
        #endregion

        #region Constructor
        public MoveInventoryCommand(
            ILogger<MoveInventoryCommand> logger,
            IMovementInventoryRepository movementInventoryRepository,
            IProductRepository productRepository)
        {
            Logger = logger;
            MovementInventoryRepository = movementInventoryRepository;
            ProductRepository = productRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<MoveInventoryResponse> Handle(MoveInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in request.Products)
                {
                    var product = await ProductRepository.GetAsync(item.ProductId);

                    if (product is null)
                    {
                        throw new NotFoundException("product Not Found");
                    }

                    product.Available = product.Ammount - item.AmmountWithdrawal;
                    await ProductRepository.UpdateAsync(product);
                }

                var moviment = await MovementInventoryRepository.CreateAsync((MovimentInventoryEntity)request);


                return (MoveInventoryResponse)moviment;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        #endregion
    }
}