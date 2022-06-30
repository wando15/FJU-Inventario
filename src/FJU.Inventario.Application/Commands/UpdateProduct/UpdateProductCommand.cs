using FJU.Inventario.Application.Common.ValidatePermision;
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
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public UpdateProductCommand(
            ILogger<UpdateProductCommand> logger,
            IProductRepository repository,
            IVerifyPermission permission)
        {
            Logger = logger;
            Repository = repository;
            Permission = permission;
        }
        #endregion

        #region Implementation
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsAdmin())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var currentProduct = await Repository.GetProductNameAsync(request.Name);

                if (currentProduct is not null && currentProduct.Id != request.Id)
                {
                    throw new UnprocessableEntityException("Product already existis");
                }

                currentProduct = await Repository.GetAsync(request.Id);
                request.Available = currentProduct.Ammount - currentProduct.Unavailable;

                await Repository.UpdateAsync((ProductEntity)request);

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
