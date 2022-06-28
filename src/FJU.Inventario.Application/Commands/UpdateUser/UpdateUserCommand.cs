using FJU.Inventario.Application.Commands.CreateUser;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        #region Properties
        private ILogger<CreateUserCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        #endregion

        #region Constructor
        public UpdateUserCommand(
            ILogger<CreateUserCommand> logger,
            IUserRepository userRepository)
        {
            Logger = logger;
            UserRepository = userRepository;
        }
        #endregion

        #region Implementation Handler
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await UserRepository.GetAsync(request?.Id);

                if (currentUser != null)
                {
                    throw new UnprocessableEntityException("User not found");
                }

                request.Password = currentUser?.Password;

                await UserRepository.UpdateAsync(request?.Id, (UserEntity)request);

                return (UpdateUserResponse)(UserEntity)request;
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
