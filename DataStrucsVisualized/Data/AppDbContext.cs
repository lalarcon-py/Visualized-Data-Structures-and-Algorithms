using Microsoft.EntityFrameworkCore;

namespace DataStrucsVisualized.Data;

public class AppDbContext : DbContext
{
    public DbSet<BinaryTreeModel> BinaryTreeModels { get; set; }
    public DbSet<LinkedList> LinkedLists { get; set; }
    public DbSet<LinkedListNode> LinkedListNodes { get; set; }
    public DbSet<TreeNode> TreeNodes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("your_connection_string_here");
    }
}