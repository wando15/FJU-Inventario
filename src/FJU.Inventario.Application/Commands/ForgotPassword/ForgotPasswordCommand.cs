using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using Bcrypt = BCrypt.Net.BCrypt;

namespace FJU.Inventario.Application.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        #region Properties
        private ILogger<ForgotPasswordCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        #endregion

        #region Constructor
        public ForgotPasswordCommand(
            ILogger<ForgotPasswordCommand> logger,
            IUserRepository userRepository)
        {
            Logger = logger;
            UserRepository = userRepository;
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

                user.Password = Bcrypt.HashPassword(request.NewPassword);

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
