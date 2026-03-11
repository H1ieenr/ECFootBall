using ECFootball.Identity.API._Service.Interface;
using ECFootball.Identity.API._Service.Service;
using ECFootball.Infrastructure.Shared._Services.Interfaces;
using ECFootball.Infrastructure.Shared._Services.Services;

namespace ECFootball.Identity.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddScoped<ISeedDataService, SeedDataService>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<IFileService, FileService>();
        }

    }
}
