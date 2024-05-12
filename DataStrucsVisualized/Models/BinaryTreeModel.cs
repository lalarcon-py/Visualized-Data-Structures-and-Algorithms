namespace DataStrucsVisualized;

public class BinaryTreeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RootId { get; set; }
    public virtual TreeNode Root { get; set; }
}