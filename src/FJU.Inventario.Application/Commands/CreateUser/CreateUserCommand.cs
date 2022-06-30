using FJU.Inventario.Application.Common.EncriptedPassword;
using FJU.Inventario.Application.Common.ValidatePermision;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        #region Properties
        private ILogger<CreateUserCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        private IEncryptionPassword EncryptionPassword { get; }
        private IVerifyPermission Permission { get; }
        #endregion

        #region Constructor
        public CreateUserCommand(
            ILogger<CreateUserCommand> logger,
            IUserRepository userRepository,
            IEncryptionPassword encryptionPassword,
            IVerifyPermission permission)
        {
            Logger = logger;
            UserRepository = userRepository;
            EncryptionPassword = encryptionPassword;
            Permission = permission;
        }
        #endregion

        #region Implementation Handler
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await Permission.IsAdmin())
                {
                    throw new UnprocessableEntityException("User higher hierarchical level required");
                }

                var existisUser = await UserRepository.GetUserNameAsync(request?.UserName);

                if (existisUser != null)
                {
                    throw new UnprocessableEntityException("User already exists");
                }

                request.Password = await EncryptionPassword.Encrypt(request.Password);

                var newUser = await UserRepository.CreateAsync((UserEntity)request);

                if (newUser is null)
                {
                    throw new UnprocessableEntityException("Failed to create User");
                }

                return (CreateUserResponse)newUser;
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
