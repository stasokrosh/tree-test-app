using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.Services.DTO
{
    public class JournalListItemDTO
    {
        public long Id { get; set; }
        public string EventId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
