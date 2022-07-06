using FJU.Inventario.Domain.Entities;
using FJU.Inventario.Infrastructure.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FJU.Inventario.Application.Common
{
    public class TokenService : ITokenService
    {
        #region Properties
        public ILogger<TokenService> Logger { get; set; }
        private TokenConfig Config { get; }

        #endregion

        #region Constructor
        public TokenService(
            ILogger<TokenService> logger,
            IOptions<TokenConfig> config)
        {
            Logger = logger;
            Config = config.Value;
        }
        #endregion

        #region Implementation Interface
        public Task<string> GenerateToken(UserEntity user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Password),
                    new Claim(ClaimTypes.Role, "user")
                };

                if (user.IsAdmin)
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));

                if (user.IsCoordinator)
                    claims.Add(new Claim(ClaimTypes.Role, "coordenator"));
                        
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Config.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Task.FromResult(tokenHandler.WriteToken(token));
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
