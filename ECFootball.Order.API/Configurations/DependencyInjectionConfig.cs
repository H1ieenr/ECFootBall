using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API._Service.Service;

namespace ECFootball.Order.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
