using System;
using System.Collections.Generic;
using System.Linq;
using DataStrucsVisualized.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataStrucsVisualized;

public class TreeNode
{
    public int Id { get; set; }
    public int Value { get; set; }
    public int? LeftId { get; set; }
    public int? RightId { get; set; }
    public virtual TreeNode Left { get; set; }
    public virtual TreeNode Right { get; set; }
}

public class BinaryTree
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RootId { get; set; }
    public virtual TreeNode Root { get; set; }
}

public class BinaryTreeDbContext : DbContext
{
    public DbSet<BinaryTree> BinaryTrees { get; set; }
    public DbSet<TreeNode> TreeNodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("your_connection_string");
    }
}
/*
public class BinaryTreeService : IBinaryTreeService
{
    private readonly BinaryTreeDbContext _dbContext;

    public BinaryTreeService(BinaryTreeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;

        TreeNode temp = root.Left;
        root.Left = InvertTree(root.Right);
        root.Right = InvertTree(temp);

        return root;
    }

    public TreeNode BalanceTree(TreeNode root)
    {
        if (root == null)
            return null;

        List<int> values = TraverseTree(root);
        return BuildBalancedTree(values, 0, values.Count - 1);
    }

    private List<int> TraverseTree(TreeNode node)
    {
        List<int> values = new List<int>();
        if (node != null)
        {
            values.AddRange(TraverseTree(node.Left));
            values.Add(node.Value);
            values.AddRange(TraverseTree(node.Right));
        }
        return values;
    }

    private TreeNode BuildBalancedTree(List<int> values, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        TreeNode node = new TreeNode { Value = values[mid] };
        node.Left = BuildBalancedTree(values, start, mid - 1);
        node.Right = BuildBalancedTree(values, mid + 1, end);
        return node;
    }

    public BinaryTree GetBinaryTreeById(int id)
    {
        return _dbContext.BinaryTrees.Include(bt => bt.Root).FirstOrDefault(bt => bt.Id == id);
    }

    public void SaveBinaryTree(BinaryTree binaryTree)
    {
        _dbContext.BinaryTrees.Add(binaryTree);
        _dbContext.SaveChanges();
    }

    public BinaryTree CreateBinaryTree(int[] values)
    {
        if (values == null || values.Length == 0)
        {
            throw new ArgumentException("Values cannot be null or empty.");
        }

        BinaryTree binaryTree = new BinaryTree();
        binaryTree.Root = CreateTreeNode(values, 0);

        _dbContext.BinaryTrees.Add(binaryTree);
        _dbContext.SaveChanges();

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
        return _dbContext.BinaryTrees.Include(bt => bt.Root).ToList();
    }
}

[ApiController]
[Route("api/[controller]")]
public class BinaryTreeController : ControllerBase
{
    private readonly BinaryTreeService _binaryTreeService;

    public BinaryTreeController(BinaryTreeService binaryTreeService)
    {
        _binaryTreeService = binaryTreeService;
    }

    [HttpGet("{id}")]
    public ActionResult<BinaryTree> GetBinaryTree(int id)
    {
        BinaryTree binaryTree = _binaryTreeService.GetBinaryTreeById(id);
        if (binaryTree == null)
            return NotFound();

        return Ok(binaryTree);
    }

    [HttpPost("invert/{id}")]
    public ActionResult<BinaryTree> InvertBinaryTree(int id)
    {
        BinaryTree binaryTree = _binaryTreeService.GetBinaryTreeById(id);
        if (binaryTree == null)
            return NotFound();

        binaryTree.Root = _binaryTreeService.InvertTree(binaryTree.Root);
        _binaryTreeService.SaveBinaryTree(binaryTree);

        return Ok(binaryTree);
    }

    [HttpPost("balance/{id}")]
    public ActionResult<BinaryTree> BalanceBinaryTree(int id)
    {
        BinaryTree binaryTree = _binaryTreeService.GetBinaryTreeById(id);
        if (binaryTree == null)
            return NotFound();

        binaryTree.Root = _binaryTreeService.BalanceTree(binaryTree.Root);
        _binaryTreeService.SaveBinaryTree(binaryTree);

        return Ok(binaryTree);
    }
} */