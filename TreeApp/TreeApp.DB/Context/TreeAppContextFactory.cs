using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TreeApp.DB.Context
{
    public class TreeAppContextFactory : IDesignTimeDbContextFactory<TreeAppDBContext>
    {
        TreeAppDBContext IDesignTimeDbContextFactory<TreeAppDBContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TreeAppDBContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.db.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
            return new TreeAppDBContext(optionsBuilder.Options);
        }
    }
}
