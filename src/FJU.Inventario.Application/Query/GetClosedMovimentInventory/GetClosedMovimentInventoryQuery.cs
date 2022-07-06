using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryQuery : IRequestHandler<GetClosedMovimentInventoryRequest, GetClosedMovimentInventoryResponse>
    {
        #region Properties
        private ILogger<GetClosedMovimentInventoryQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        #endregion

        #region Constructor
        public GetClosedMovimentInventoryQuery(
            ILogger<GetClosedMovimentInventoryQuery> logger,
            IMovementInventoryRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetClosedMovimentInventoryResponse> Handle(GetClosedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var moviments = await Repository.GetClosedMovementInventoryAsync(request.UserId);

                if (moviments is null)
                {
                    throw new NotFoundException("Closed moves Not Found");
                }

                return new GetClosedMovimentInventoryResponse
                {
                    Result = new BaseResult<IList<MovimentInventoryEntity>>()
                    {
                        IsSuccess = true,
                        Message = "these is open moves found",
                        StatusCode = HttpStatusCode.OK,
                        Data = moviments
                    }
                };
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
