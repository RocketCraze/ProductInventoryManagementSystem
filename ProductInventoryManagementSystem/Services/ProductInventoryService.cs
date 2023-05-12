namespace ProductInventoryManagementSystem.Services
{
    using ProductInventoryManagementSystem.Data;
    using ProductInventoryManagementSystem.Models;
    using ProductInventoryManagementSystem.Interfaces;

    public class ProductInventoryService : IProductInventoryService
    {
        private readonly ApplicationDbContext context;

        public ProductInventoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProductInventory> GetAll()
        {
            return this.context.Set<ProductInventory>().ToList();
        }

        
    }
}
