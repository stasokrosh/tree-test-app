using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreeApp.DB.Config;

namespace TreeApp.Services.Config
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            return services
                .AddAutoMapper(typeof(ConfigExtensions))
                .AddDB(config)
                .AddTransient<ITreeService, TreeService>()
                .AddTransient<ITreeNodeService, TreeNodeService>();
        }
    }
}
