namespace ProductInventoryManagementSystem.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

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

        [HttpPost]
        public IActionResult Create(string values)
        { 
            var model = new ProductInventory();
            JsonConvert.PopulateObject(values, model);

            this.productInventoryService.Add(model);

            return this.Ok();
        }

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var model = this.productInventoryService.GetAll().First(_ => _.ProductID == key);
            JsonConvert.PopulateObject(values, model);

            this.productInventoryService.Update(model);

            return this.Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var model = this.productInventoryService.GetAll().First(_ => _.ProductID == key);
            this.productInventoryService.Delete(key);

            return this.Ok();
        }
    }
}
