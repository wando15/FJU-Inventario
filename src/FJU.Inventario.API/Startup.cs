using FJU.Inventario.Application.Commands.CreateUser;
using FJU.Inventario.CrossCutting.DependenceInjection;
using FJU.Inventario.CrossCutting.Middleware.Authorization;
using FJU.Inventario.CrossCutting.Middleware.ExceptionHandler;
using MediatR;

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
            services.AddAuthentication();
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

        public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory logger)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "FJU Inventario");
                options.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<VerifyAuthorizationHandler>();
            app.UseApiVersioning();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
