using FJU.Inventario.Domain.Repositories;
using FJU.Inventario.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FJU.Inventario.CrossCutting.DependenceInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
