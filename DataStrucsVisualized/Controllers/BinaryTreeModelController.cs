using DataStrucsVisualized.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataStrucsVisualized.Controllers;

public class BinaryTreeModelController : ControllerBase
{
    private readonly IBinaryTreeService _binaryTreeService;

    public BinaryTreeModelController(IBinaryTreeService binaryTreeService)
    {
        _binaryTreeService = binaryTreeService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<BinaryTree>> GetBinaryTrees()
    {
        var binaryTrees = _binaryTreeService.GetAllBinaryTrees();
        return Ok(binaryTrees);
    }
    
    [HttpPost]
    public ActionResult<BinaryTree> CreateBinaryTreeModel([FromBody] int[] values)
    {
        var createdBinaryTree = _binaryTreeService.CreateBinaryTree(values);
        return CreatedAtAction(nameof(GetBinaryTrees), new { id = createdBinaryTree.Id }, createdBinaryTree);
    }
}