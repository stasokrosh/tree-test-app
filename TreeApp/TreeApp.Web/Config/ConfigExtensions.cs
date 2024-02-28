using TreeApp.Services.Config;

namespace TreeApp.Web.Config
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddWebApp(
            this IServiceCollection services,
            IConfiguration config)
        {
            return services
                .AddAutoMapper(typeof(Program))
                .AddServices(config);
        }
    }
}
