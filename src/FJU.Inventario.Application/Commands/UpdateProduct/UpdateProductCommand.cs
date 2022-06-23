using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        #region Properties
        private ILogger<UpdateProductCommand> Logger { get; }
        private IProductRepository Repository { get; }
        #endregion

        #region Constructor
        public UpdateProductCommand(
            ILogger<UpdateProductCommand> logger,
            IProductRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var currentProduct = await Repository.GetProductNameAsync(request.Name);

                if (currentProduct != null)
                {
                    throw new UnprocessableEntityException("Product already existis");
                }

                await Repository.UpdateAsync(request.Id, (ProductEntity)request);

                return (UpdateProductResponse)(ProductEntity)request;
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
