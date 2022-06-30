using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryQuery : IRequestHandler<GetClosedMovimentInventoryRequest, GetClosedMovimentInventoryResponse>
    {
        #region Properties
        private ILogger<GetClosedMovimentInventoryQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        private IHttpContextAccessor Context { get; }
        #endregion

        #region Constructor
        public GetClosedMovimentInventoryQuery(
            ILogger<GetClosedMovimentInventoryQuery> logger,
            IMovementInventoryRepository repository,
            IHttpContextAccessor context)
        {
            Logger = logger;
            Repository = repository;
            Context = context;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetClosedMovimentInventoryResponse> Handle(GetClosedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Context.HttpContext.Request.Headers["UserId"];
                var moviments = await Repository.GetClosedMovementInventoryAsync(userId);

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
