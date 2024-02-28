using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TreeApp.DB.Entities.Config
{
    internal class TreeNodeConfig : AbstractEntityConfig<TreeNode>
    {
        public override void Configure(EntityTypeBuilder<TreeNode> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => new { x.ParentId, x.Name }).IsUnique();
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Root)
                .WithMany(x => x.RootChildren)
                .HasForeignKey(x => x.RootId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
