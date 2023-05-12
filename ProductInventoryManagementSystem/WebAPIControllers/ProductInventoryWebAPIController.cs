namespace ProductInventoryManagementSystem.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using ProductInventoryManagementSystem.Interfaces;
    using ProductInventoryManagementSystem.Models;

    [Route("api/[controller]")]
    public class ProductInventoryWebAPIController : Controller
    {
        private readonly IProductInventoryService productInventoryService;

        public ProductInventoryWebAPIController(IProductInventoryService productInventoryService)
        {
            this.productInventoryService = productInventoryService;
        }

        [HttpGet("/GetProductInventory")]
        public IActionResult GetProductInventory(DataSourceLoadOptions loadOptions)
        {
            var productInventory = new List<ProductInventory>();

            productInventory = this.productInventoryService.GetAll();

            return this.Json(DataSourceLoader.Load(productInventory, loadOptions));
        }
    }
}
