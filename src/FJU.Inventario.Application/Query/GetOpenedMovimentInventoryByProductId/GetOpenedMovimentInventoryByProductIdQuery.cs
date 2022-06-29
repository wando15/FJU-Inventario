using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventoryByProductId
{
    public class GetOpenedMovimentInventoryByProductIdQuery : IRequestHandler<GetOpenedMovimentInventoryByProductIdParams, GetOpenedMovimentInventoryByProductIdResponse>
    {
        #region Properties
        private ILogger<GetOpenedMovimentInventoryByProductIdQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        #endregion

        #region Constructor
        public GetOpenedMovimentInventoryByProductIdQuery(
            ILogger<GetOpenedMovimentInventoryByProductIdQuery> logger,
            IMovementInventoryRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetOpenedMovimentInventoryByProductIdResponse> Handle(GetOpenedMovimentInventoryByProductIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var moviments = await Repository.GetOpenedMovementInventoryByProductIdAsync(request.Id);

                if (moviments is null)
                {
                    throw new NotFoundException("Opened moves Not Found");
                }

                return (GetOpenedMovimentInventoryByProductIdResponse)moviments;
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
