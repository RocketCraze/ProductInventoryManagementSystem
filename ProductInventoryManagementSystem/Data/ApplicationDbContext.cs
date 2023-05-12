namespace ProductInventoryManagementSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using ProductInventoryManagementSystem.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<ProductInventory> ProductInventory { get; set; }
    }
}
