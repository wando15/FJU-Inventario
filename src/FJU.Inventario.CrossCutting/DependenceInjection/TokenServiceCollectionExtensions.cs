using FJU.Inventario.Infrastructure.Config;
using FJU.Inventario.Infrastructure.CunstomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FJU.Inventario.CrossCutting.DependenceInjection
{
    public static class TokenServiceCollectionExtensions
    {
        public static IServiceCollection AddTokenConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("TokenConfig");

            if (section == null)
            {
                throw new NotFoundException("Not found section TokenConfig");
            }

            services.Configure<TokenConfig>(section);

            TokenConfig config = section.Get<TokenConfig>();

            var key = Encoding.ASCII.GetBytes(config.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
