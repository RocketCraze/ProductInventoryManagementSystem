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

        public void Add(ProductInventory productInventory)
        {
            this.context.Set<ProductInventory>().Add(productInventory);
            this.context.SaveChanges();
        }

        public void Update(ProductInventory productInventory) 
        {
            this.context.Set<ProductInventory>().Attach(productInventory);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProductInventory productInventory = this.context.Set<ProductInventory>().Find(id);
            this.context.Remove(productInventory);
            this.context.SaveChanges();
        }
    }
}
