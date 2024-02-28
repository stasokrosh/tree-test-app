using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.Services.DTO
{
    public class JournalListDTO
    {
        public int Skip { get; set; }
        public int Count { get; set; }

        public IEnumerable<JournalListItemDTO> Items { get;set; }
    }
}
