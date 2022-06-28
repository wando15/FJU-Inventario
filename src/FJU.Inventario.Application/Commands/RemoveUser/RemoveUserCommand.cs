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
        #endregion

        #region Constructor
        public RemoveUserCommand(
            ILogger<RemoveUserCommand> logger,
            IUserRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        #region Implementation Handler
        public async Task<RemoveUserResponse> Handle(RemoveUserParams request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await Repository.GetAsync(request?.Id);

                if (user != null)
                {
                    throw new NotFoundException("User already exists");
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
