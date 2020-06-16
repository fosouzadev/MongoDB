using ApiMongoDB.Model.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApiMongoDB.StartupConfiguration
{
    public static class MongoDb
    {
        public static IServiceCollection ConfigureMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDB"));
            services.AddSingleton<IMongoDbConfiguration>(sp => sp.GetRequiredService<IOptions<MongoDbConfiguration>>().Value);
            return services;
        }
    }
}