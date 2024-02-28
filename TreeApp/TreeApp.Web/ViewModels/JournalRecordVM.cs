namespace TreeApp.Web.ViewModels
{
    public class JournalRecordVM
    {
        public long Id { get; set; }
        public string EventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}
