using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Query.GetProductById
{
    public class GetProductByIdQuery : IRequestHandler<GetProductByIdParams, GetProductByIdResponse>
    {
        #region Properties
        private ILogger<GetProductByIdQuery> Logger { get; }
        private IProductRepository Repository { get; }
        #endregion

        #region Constructor
        public GetProductByIdQuery(
            ILogger<GetProductByIdQuery> logger,
            IProductRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<GetProductByIdResponse> Handle(GetProductByIdParams request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await Repository.GetAsync(request?.Id);

                if (project is null)
                {
                    throw new NotFoundException("Products not found");
                }

                return (GetProductByIdResponse)project;
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
