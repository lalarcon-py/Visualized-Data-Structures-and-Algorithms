using DataStrucsVisualized;

namespace DataStrucsVisualized.Services;

public interface IBinaryTreeService
{
    BinaryTree CreateBinaryTree(int[] values);
    IEnumerable<BinaryTree> GetAllBinaryTrees();
}
