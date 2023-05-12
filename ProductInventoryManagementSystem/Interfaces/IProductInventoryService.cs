namespace ProductInventoryManagementSystem.Interfaces
{
    using ProductInventoryManagementSystem.Models;

    public interface IProductInventoryService
    {
        List<ProductInventory> GetAll();   
        
        void Add(ProductInventory product);

        void Update(ProductInventory product);

        void Delete(int id);
    }
}
