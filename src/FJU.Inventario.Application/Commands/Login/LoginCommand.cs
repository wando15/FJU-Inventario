using FJU.Inventario.Application.Common;
using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.CunstomException;
using MediatR;
using Microsoft.Extensions.Logging;
using Bcrypt = BCrypt.Net.BCrypt;

namespace FJU.Inventario.Application.Commands.Login
{
    public class LoginCommand : IRequestHandler<LoginRequest, LoginResponse>
    {
        #region Properties
        private ILogger<LoginCommand> Logger { get; }
        private IUserRepository UserRepository { get; }
        private ITokenService TokenService { get; }
        #endregion

        #region Constructor
        public LoginCommand(
            ILogger<LoginCommand> logger,
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            Logger = logger;
            UserRepository = userRepository;
            TokenService = tokenService;
        }
        #endregion

        #region Implementation Handler
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await UserRepository.GetUserNameAsync(request?.UserName);

                if (user is null || !user.IsActive || !Bcrypt.Verify(request.Password, user.Password))
                {
                    throw new UnauthorizedException("Username or password incorrect");
                }

                var token = await TokenService.GenerateToken(user);

                return (LoginResponse)token;
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
