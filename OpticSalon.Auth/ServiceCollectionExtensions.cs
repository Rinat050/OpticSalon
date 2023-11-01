using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpticSalon.Auth.Managers;
using OpticSalon.Auth.Models;

namespace OpticSalon.Auth
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpticSalonIdentityContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseNpgsql(configuration.GetConnectionString("Default")!,
                    npgsqlOptions =>
                    {
                        npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });

            services.AddIdentity<OpticSalonUser, OpticSalonRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<OpticSalonRole>()
                .AddEntityFrameworkStores<OpticSalonIdentityContext>()
                .AddSignInManager<OpticSalonSignInManager>();

            return services;
        }
    }
}
