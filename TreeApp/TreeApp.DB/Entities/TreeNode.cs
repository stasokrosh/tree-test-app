namespace TreeApp.DB.Entities
{
    public class TreeNode : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long? ParentId { get; set; }
        public TreeNode Parent { get; set; }

        public long? RootId { get; set; }
        public TreeNode Root { get; set; }

        public ICollection<TreeNode> Children { get; set;}

        public ICollection<TreeNode> RootChildren { get; set;}
    }
}
