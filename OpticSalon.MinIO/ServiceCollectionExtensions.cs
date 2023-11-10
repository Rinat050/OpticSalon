using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using OpticSalon.Domain.FileStorage;

namespace OpticSalon.MinIO
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMinio(configureClient => 
                configureClient
                    .WithEndpoint(configuration["MinIO:EndPoint"])
                    .WithCredentials(configuration["MinIO:AccessKey"], configuration["MinIO:SecretKey"]));

            services.AddScoped<IFileStorage, FileStorage>();

            return services;
        }
    }
}
