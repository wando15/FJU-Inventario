using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryQuery : IRequestHandler<GetOpenedMovimentInventoryRequest, GetOpenedMovimentInventoryResponse>
    {
        #region Properties
        private ILogger<GetOpenedMovimentInventoryQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        #endregion

        #region Constructor
        public GetOpenedMovimentInventoryQuery(
            ILogger<GetOpenedMovimentInventoryQuery> logger,
            IMovementInventoryRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetOpenedMovimentInventoryResponse> Handle(GetOpenedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var moviments = await Repository.GetOpenedMovementInventoryAsync(request.UserId);

                if (moviments is null)
                {
                    throw new NotFoundException("Opened moves Not Found");
                }

                return new GetOpenedMovimentInventoryResponse
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
