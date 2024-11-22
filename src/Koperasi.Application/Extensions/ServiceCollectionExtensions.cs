using Koperasi.Infrastructure.Abstractions;
using Koperasi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Koperasi.Application.Interfaces;
using Koperasi.Application.Services;

namespace Koperasi.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOTPService, OTPService>();

            return services;
        }
    }
}
