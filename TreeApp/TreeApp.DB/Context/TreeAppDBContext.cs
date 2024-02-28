using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace TreeApp.DB.Context
{
    internal class TreeAppDBContext : DbContext
    {
        public TreeAppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TreeAppDBContext).Assembly);
        }
    }
}
