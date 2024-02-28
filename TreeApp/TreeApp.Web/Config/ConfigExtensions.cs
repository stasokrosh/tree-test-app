using TreeApp.Services.Config;
using TreeApp.Web.Middleware;

namespace TreeApp.Web.Config
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddWebApp(
            this IServiceCollection services,
            IConfiguration config)
        {
            return services
                .AddServices(config)
                .AddTransient<SecureExceptionMiddleware>();
        }
    }
}
