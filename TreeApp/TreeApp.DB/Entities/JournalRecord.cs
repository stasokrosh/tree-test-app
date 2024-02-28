using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.DB.Entities
{
    public class JournalRecord : IEntity
    {
        public long Id { get; set; }
        public string EventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}
