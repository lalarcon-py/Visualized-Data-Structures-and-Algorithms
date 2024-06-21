namespace DataStructureVisualizer.DataStructures;

public class TreeNode
{
    public int Data;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(TreeNode node)
    {
        int Data = this.Data;
        Left = node.Left;
        
    }

    public void InOrder(TreeNode node)
    {
        
    }
}