using ECFootball.Infrastructure.Shared._Services.Interfaces;
using ECFootball.Infrastructure.Shared._Services.Services;
using ECFootBall._Service.Interfaces;
using ECFootBall._Service.Services;

namespace ECFootBall.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeService, SizeService>();

            services.AddScoped<IFileService, FileService>();
        }

    }
}
