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
        #endregion

        #region Constructor
        public RemoveProductCommand(
            ILogger<RemoveProductCommand> logger,
            IUserRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveProductResponse> Handle(RemoveProductParams request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await Repository.GetAsync(request?.Id);

                if (user != null)
                {
                    throw new NotFoundException("User already exists");
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
