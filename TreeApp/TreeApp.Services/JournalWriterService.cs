using AutoMapper;
using TreeApp.DB;
using TreeApp.DB.Entities;
using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    internal class JournalWriterService : IJournalWriterService
    {
        private readonly IJournalRecordRepository _journalRecordRepository;
        private readonly IMapper _mapper;

        public JournalWriterService(
            IJournalRecordRepository journalRecordRepository, 
            IMapper mapper)
        {
            _journalRecordRepository = journalRecordRepository;
            _mapper = mapper;
        }

        public async Task<JournalRecordDTO> WriteRecordAsync(string eventId, string text)
        {
            var record = new JournalRecord
            {
                EventId = eventId,
                Text = text,
                CreatedAt = DateTime.UtcNow
            };

            record.Id = await _journalRecordRepository
                .CreateAsync(record);

            return _mapper.Map<JournalRecordDTO>(record);
        }
    }
}
