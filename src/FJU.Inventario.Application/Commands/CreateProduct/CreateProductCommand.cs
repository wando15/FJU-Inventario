using FJU.Inventario.Application.Common.ValidatePermision;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        #region Properties
        private ILogger<CreateProductCommand> Logger { get; }
        private IProductRepository Repository { get; }
        private IVerifyPermission Permission { get; }

        #endregion

        #region Constructor
        public CreateProductCommand(
            ILogger<CreateProductCommand> logger,
            IProductRepository repository,
            IVerifyPermission permission)
        {
            Logger = logger;
            Repository = repository;
            Permission = permission;
        }
        #endregion

        #region Implementation
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsCoordenate())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var currentProduct = await Repository.GetProductNameAsync(request.Name);

                if (currentProduct != null)
                {
                    throw new UnprocessableEntityException("Product already existis");
                }

                var newProduct = await Repository.CreateAsync((ProductEntity)request);

                return (CreateProductResponse)newProduct;
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
