﻿using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryQuery : IRequestHandler<GetOpenedMovimentInventoryRequest, GetOpenedMovimentInventoryResponse>
    {
        #region Properties
        private ILogger<GetOpenedMovimentInventoryQuery> Logger { get; }
        private IMovementInventoryRepository Repository { get; }
        private IHttpContextAccessor Context { get; }
        #endregion

        #region Constructor
        public GetOpenedMovimentInventoryQuery(
            ILogger<GetOpenedMovimentInventoryQuery> logger,
            IMovementInventoryRepository repository,
            IHttpContextAccessor context)
        {
            Logger = logger;
            Repository = repository;
            Context = context;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetOpenedMovimentInventoryResponse> Handle(GetOpenedMovimentInventoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Context.HttpContext.Request.Headers["UserId"].ToString();
                var moviments = await Repository.GetOpenedMovementInventoryAsync(userId);

                if(moviments is null)
                {
                    throw new NotFoundException("Opened moves Not Found");
                }

                return (GetOpenedMovimentInventoryResponse)moviments;
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
