using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetProductByProjectId
{
    public class GetProductByProjectIdQuery : IRequestHandler<GetProductByProjectIdParams, GetProductByProjectIdResponse>
    {
        #region Properties
        private ILogger<GetProductByProjectIdQuery> Logger { get; }
        private IProductRepository Repository { get; }
        #endregion

        #region Constructor
        public GetProductByProjectIdQuery(
            ILogger<GetProductByProjectIdQuery> logger,
            IProductRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetProductByProjectIdResponse> Handle(GetProductByProjectIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var Products = await Repository.GetProductByProjectIdAsync(request.Id);

                if (Products is null)
                {
                    throw new NotFoundException("Products not found in this project");
                }

                return (GetProductByProjectIdResponse)Products;
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
