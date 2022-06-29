using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProducts
{
    public class GetProductsQuery : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        #region Properties
        private ILogger<GetProductsQuery> Logger { get; }
        private IProductRepository Repository { get; }
        #endregion

        #region Constructor
        public GetProductsQuery(
            ILogger<GetProductsQuery> logger,
            IProductRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Products = await Repository.GetAsync();

                if (Products is null)
                {
                    throw new NotFoundException("Products not found");
                }

                return new GetProductsResponse
                {
                    Result = new BaseResult<IList<ProductEntity>>()
                    {
                        IsSuccess = true,
                        Message = "these is products found",
                        StatusCode = HttpStatusCode.OK,
                        Data = Products
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
