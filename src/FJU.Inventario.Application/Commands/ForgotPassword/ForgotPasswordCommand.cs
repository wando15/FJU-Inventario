using FJU.Inventario.Application.Common.EncriptedPassword;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FJU.Inventario.Application.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        #region Properties
        private ILogger<ForgotPasswordCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        private IEncryptionPassword EncryptionPassword { get; }
        #endregion

        #region Constructor
        public ForgotPasswordCommand(
            ILogger<ForgotPasswordCommand> logger,
            IUserRepository userRepository,
            IEncryptionPassword encryptionPassword)
        {
            Logger = logger;
            UserRepository = userRepository;
            EncryptionPassword = encryptionPassword;
        }
        #endregion

        #region Implementation Handler
        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await UserRepository.GetAsync(request?.Id);

                if (user is null)
                {
                    throw new NotFoundException("User not found");
                }

                user.Password = await EncryptionPassword.Encrypt(request.NewPassword);

                await UserRepository.UpdateAsync(user);

                return (ForgotPasswordResponse)true;
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
