using FJU.Inventario.Application.Commands.RemoveUser;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.RemoveProject
{
    public class RemoveProjectCommand : IRequestHandler<RemoveProjectParams, RemoveProjectResponse>
    { 
        #region Properties
        private ILogger<RemoveProjectCommand> Logger { get; }
        private IUserRepository Repository { get; }
        #endregion

        #region Constructor
        public RemoveProjectCommand(
            ILogger<RemoveProjectCommand> logger,
            IUserRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveProjectResponse> Handle(RemoveProjectParams request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await Repository.GetAsync(request?.Id);

                if (user != null)
                {
                    throw new NotFoundException("User already exists");
                }

                await Repository.RemoveAsync(user);

                return (RemoveProjectResponse)true;
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
