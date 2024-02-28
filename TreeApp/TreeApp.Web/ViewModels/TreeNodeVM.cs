namespace TreeApp.Web.ViewModels
{
    public class TreeNodeVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TreeNodeVM> Children { get; set; }
    }
}
