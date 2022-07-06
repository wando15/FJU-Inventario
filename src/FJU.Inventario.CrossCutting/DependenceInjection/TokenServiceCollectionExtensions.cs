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
            var config = configuration.GetSection("TokenConfig");

            if (config == null)
            {
                throw new NotFoundException("Not found section TokenConfig");
            }

            services.Configure<TokenConfig>(config);

            var key = Encoding.ASCII.GetBytes(config.GetValue<string>("Secret"));
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
