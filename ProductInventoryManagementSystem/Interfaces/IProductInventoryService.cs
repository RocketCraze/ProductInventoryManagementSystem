namespace ProductInventoryManagementSystem.Interfaces
{
    using ProductInventoryManagementSystem.Models;

    public interface IProductInventoryService
    {
        List<ProductInventory> GetAll();      
    }
}
