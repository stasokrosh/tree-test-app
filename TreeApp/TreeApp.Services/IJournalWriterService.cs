using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    public interface IJournalWriterService
    {
        Task<JournalRecordDTO> WriteRecordAsync(string eventId, string text);
    }
}
