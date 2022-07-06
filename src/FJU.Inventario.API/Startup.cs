using FJU.Inventario.CrossCutting.DependenceInjection;
using FJU.Inventario.CrossCutting.Middleware.Authorization;
using FJU.Inventario.CrossCutting.Middleware.ExceptionHandler;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FJU.Inventario.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddOptions();
            services.AddTokenConfig(Configuration);
            services.AddAuthorization();
            services.AddVersion();
            services.AddSwagger();
            services.AddLogging();
            services.AddMongo(Configuration);
            services.AddRepositories();
            services.AddCors();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddCommands();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
