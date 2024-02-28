namespace TreeApp.Services.DTO
{
    public class TreeNodeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TreeNodeDTO> Children { get; set; }
    }
}
