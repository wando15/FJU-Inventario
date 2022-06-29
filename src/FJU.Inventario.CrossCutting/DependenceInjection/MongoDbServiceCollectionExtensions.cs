using FJU.Inventario.Infrastructure.Config;
using FJU.Inventario.Infrastructure.CunstomException;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace FJU.Inventario.CrossCutting.DependenceInjection
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("MongoConfig");

            if (section is null)
            {
                throw new NotFoundException("Configure Section MongoConfig not Found");
            }

            services.Configure<MongoConfig>(section);

            MongoConfig config = section.Get<MongoConfig>();

            var mongoClient = new MongoClient(config.ConnectionString);

            services.AddSingleton(mongoClient);
            services.AddSingleton(mongoClient.GetDatabase(config.DatabaseName));

            return services;
        }
    }
}
