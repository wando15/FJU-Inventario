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
        private IHttpContextAccessor Context { get; }
        #endregion

        #region Constructor
        public MoveInventoryCommand(
            ILogger<MoveInventoryCommand> logger,
            IMovementInventoryRepository movementInventoryRepository,
            IProductRepository productRepository,
            IHttpContextAccessor context)
        {
            Logger = logger;
            MovementInventoryRepository = movementInventoryRepository;
            ProductRepository = productRepository;
            Context = context;
        }
        #endregion

        #region Implementation Handler
        public async Task<MoveInventoryResponse> Handle(MoveInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Context.HttpContext.Request.Headers["UserId"].ToString();
                var product = await ProductRepository.GetAsync(request.ProductId);

                if (product == null)
                {
                    throw new NotFoundException("product Not Found");
                }

                product.Available = product.Ammount - request.AmmountWithdrawal;

                request.UserId = userId;
                request.ProductId = product.Id;
                var moviment = await MovementInventoryRepository.CreateAsync((MovimentInventoryEntity)request);

                await ProductRepository.UpdateAsync(product.Id, product);

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