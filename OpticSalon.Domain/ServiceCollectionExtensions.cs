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
            services.AddScoped<IFrameTypeService, FrameTypeService>();
            services.AddScoped<IFrameColorService, FrameColorService>();
            services.AddScoped<IFrameMaterialService, FrameMaterialService>();
            services.AddScoped<IImageLoadingService, ImageLoadingService>();
            services.AddScoped<IFrameService, FrameService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ILensPackageService, LensPackageService>();
            services.AddScoped<IPurposeService, PurposeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
