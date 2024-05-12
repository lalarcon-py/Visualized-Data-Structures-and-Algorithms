namespace DataStrucsVisualized.Services;

public class BinaryTreeService : IBinaryTreeService
{
    private readonly List<BinaryTree> _binaryTrees = new List<BinaryTree>();

    public BinaryTree CreateBinaryTree(int[] values)
    {
        if (values == null || values.Length == 0)
        {
            throw new ArgumentException("Values cannot be null or empty.");
        }

        BinaryTree binaryTree = new BinaryTree();
        binaryTree.Root = CreateTreeNode(values, 0);

        _binaryTrees.Add(binaryTree);

        return binaryTree;
    }

    private TreeNode CreateTreeNode(int[] values, int index)
    {
        if (index >= values.Length || values[index] == 0)
        {
            return null;
        }

        TreeNode node = new TreeNode { Value = values[index] };
        node.Left = CreateTreeNode(values, 2 * index + 1);
        node.Right = CreateTreeNode(values, 2 * index + 2);

        return node;
    }

    public IEnumerable<BinaryTree> GetAllBinaryTrees()
    {
        return _binaryTrees;
    }
}