using Microsoft.Extensions.DependencyInjection;
using OpticSalon.Domain.Services;
using OpticSalon.Domain.Services.Impl;

namespace OpticSalon.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
