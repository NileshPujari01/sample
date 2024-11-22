using Microsoft.Extensions.DependencyInjection;
using Koperasi.Infrastructure.Abstractions;
using Koperasi.Infrastructure.Persistence;
using Koperasi.Infrastructure.Repositories;

namespace Koperasi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();

            return services;
        }
    }
}
