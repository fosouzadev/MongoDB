using ApiMongoDB.Repository;
using ApiMongoDB.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMongoDB.StartupConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}