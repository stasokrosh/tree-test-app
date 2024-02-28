using AutoMapper;
using TreeApp.DB;
using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    internal class JournalService : IJournalService
    {
        private readonly IJournalRecordRepository _repository;
        private readonly IMapper _mapper;

        public JournalService(
            IJournalRecordRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<JournalRecordDTO> FindAsync(long id)
        {
            var record = await _repository.FindByIdAsync(id);

            if (record == null)
            {
                throw new SecureException(
                    "Journal record was not found");
            }

            return _mapper.Map<JournalRecordDTO>(
                record);
        }

        public async Task<JournalListDTO> GetListAsync(
            int skip, 
            int count, 
            DateTime? from, 
            DateTime? to, 
            string searchItem)
        {
            if (skip < 0 || count < 0)
            {
                throw new SecureException(
                    "Skip and count can't be negative");
            }

            if (from.HasValue && to.HasValue && from > to)
            {
                throw new SecureException(
                    "\"From\" should be after \"to\"");
            }

            var list = new JournalListDTO 
            {
                Skip = skip
            };

            list.Count = await _repository.GetCountAsync();


            list.Items = _mapper.Map<IEnumerable<JournalListItemDTO>>(
                await _repository.GetListAsync(
                    skip, count, from, to, searchItem));

            return list;
        }
    }
}
