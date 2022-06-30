using FJU.Inventario.Application.Common.ValidatePermision;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.RemoveProduct
{
    public class RemoveProductCommand : IRequestHandler<RemoveProductParams, RemoveProductResponse>
    {
        #region Properties
        private ILogger<RemoveProductCommand> Logger { get; }
        private IUserRepository Repository { get; }
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public RemoveProductCommand(
            ILogger<RemoveProductCommand> logger,
            IUserRepository repository,
            IVerifyPermission permission)
        {
            Logger = logger;
            Repository = repository;
            Permission = permission;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveProductResponse> Handle(RemoveProductParams request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsCoordenate())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var user = await Repository.GetAsync(request?.Id);

                if (user is null)
                {
                    throw new NotFoundException("Product not found");
                }

                await Repository.RemoveAsync(user);

                return (RemoveProductResponse)true;
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
