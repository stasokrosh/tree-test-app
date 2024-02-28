using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TreeApp.DB.Entities.Config
{
    internal class AbstractEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(GetType().Name.Replace("Config", ""))
                .HasKey(x => x.Id);
        }
    }
}
