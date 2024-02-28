using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.DB.Entities.Config
{
    internal class JournalRecordConfig : AbstractEntityConfig<JournalRecord>
    {
        public override void Configure(EntityTypeBuilder<JournalRecord> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.EventId).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
