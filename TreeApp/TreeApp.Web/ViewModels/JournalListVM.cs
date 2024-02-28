using TreeApp.Services.DTO;

namespace TreeApp.Web.ViewModels
{
    public class JournalListVM
    {
        public int Skip { get; set; }
        public int Count { get; set; }

        public IEnumerable<JournalListItemDTO> Items { get; set; }
    }
}
