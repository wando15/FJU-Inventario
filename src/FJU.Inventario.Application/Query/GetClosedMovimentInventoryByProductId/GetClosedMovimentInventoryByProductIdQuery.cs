using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventoryByProductId
{
    public class GetClosedMovimentInventoryByProductIdQuery : IRequestHandler<GetClosedMovimentInventoryByProductIdParams, GetClosedMovimentInventoryByProductIdResponse>
    {
        #region Properties
        private ILogger<GetClosedMovimentInventoryByProductIdQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        #endregion

        #region Constructor
        public GetClosedMovimentInventoryByProductIdQuery(
            ILogger<GetClosedMovimentInventoryByProductIdQuery> logger,
            IMovementInventoryRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetClosedMovimentInventoryByProductIdResponse> Handle(GetClosedMovimentInventoryByProductIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var moviments = await Repository.GetClosedMovementInventoryByProductIdAsync(request.Id);

                if (moviments is null)
                {
                    throw new NotFoundException("Closed moves Not Found");
                }

                return (GetClosedMovimentInventoryByProductIdResponse)moviments;
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
