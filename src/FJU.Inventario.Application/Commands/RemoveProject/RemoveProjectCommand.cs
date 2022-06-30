using FJU.Inventario.Application.Common.ValidatePermision;
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
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public RemoveProjectCommand(
            ILogger<RemoveProjectCommand> logger,
            IUserRepository repository,
            IVerifyPermission permission)
        {
            Logger = logger;
            Repository = repository;
            Permission = permission;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveProjectResponse> Handle(RemoveProjectParams request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsAdmin())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var user = await Repository.GetAsync(request?.Id);

                if (user is null)
                {
                    throw new NotFoundException("Project not exists");
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
