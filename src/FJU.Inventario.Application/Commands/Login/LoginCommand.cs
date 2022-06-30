using FJU.Inventario.Application.Common.EncriptedPassword;
using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FJU.Inventario.Application.Commands.Login
{
    public class LoginCommand : IRequestHandler<LoginRequest, LoginResponse>
    {
        #region Properties
        private ILogger<LoginCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        private IEncryptionPassword EncryptionPassword { get; }
        #endregion

        #region Constructor
        public LoginCommand(
            ILogger<LoginCommand> logger,
            IUserRepository userRepository,
            IEncryptionPassword encryptionPassword)
        {
            Logger = logger;
            UserRepository = userRepository;
            EncryptionPassword = encryptionPassword;
        }
        #endregion

        #region Implementation Handler
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await UserRepository.GetUserNameAsync(request?.UserName);

                if (user is null || !user.IsActive)
                {
                    throw new UnauthorizedException("User not authorizes");
                }

                if (!await EncryptionPassword.Compare(request.Password, user.Password))
                {
                    throw new UnauthorizedException("User not authorized");
                }

                var token = new AccessToken()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Validate = DateTime.UtcNow.AddMinutes(30)
                };

                return (LoginResponse)EncodeTo64(System.Text.Json.JsonSerializer.Serialize(token));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
        #endregion

        #region Methods
        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }
        #endregion
    }
}
