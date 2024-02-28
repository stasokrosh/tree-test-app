using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreeApp.DB.Context;

namespace TreeApp.DB.Config
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddDB(
                    this IServiceCollection services,
                    IConfiguration config)
        {
            services.AddDbContext<TreeAppDBContext>(
                options => options.UseNpgsql(
                    config.GetConnectionString("DefaultConnection")));

            return services.AddScoped<ITreeNodeRepository, TreeNodeRepository>()
                .AddScoped<IJournalRecordRepository, JournalRecordRepository>();
        }

        public static IConfigurationBuilder AddDBConfig(
                    this IConfigurationBuilder builder)
        {
            return builder.AddJsonFile("appsettings.db.json");
        }
    }
}
