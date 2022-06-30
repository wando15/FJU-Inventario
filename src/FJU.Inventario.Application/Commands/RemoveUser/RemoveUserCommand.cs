using FJU.Inventario.Application.Common.ValidatePermision;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.RemoveUser
{
    public class RemoveUserCommand : IRequestHandler<RemoveUserParams, RemoveUserResponse>
    {
        #region Properties
        private ILogger<RemoveUserCommand> Logger { get; }
        private IUserRepository Repository { get; }
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public RemoveUserCommand(
            ILogger<RemoveUserCommand> logger,
            IUserRepository repository,
            IVerifyPermission permission)
        {
            Logger = logger;
            Repository = repository;
            Permission = permission;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveUserResponse> Handle(RemoveUserParams request, CancellationToken cancellationToken)
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
                    throw new NotFoundException("User not found");
                }

                await Repository.RemoveAsync(user);

                return (RemoveUserResponse)true;
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
