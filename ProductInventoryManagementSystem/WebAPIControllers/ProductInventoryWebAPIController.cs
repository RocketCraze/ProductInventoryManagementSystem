namespace ProductInventoryManagementSystem.WebAPIControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Newtonsoft.Json;
    using ProductInventoryManagementSystem.Data;
    using ProductInventoryManagementSystem.Interfaces;
    using ProductInventoryManagementSystem.Models;

    [Route("api/[controller]")]
    public class ProductInventoryWebAPIController : Controller
    {
        private readonly IProductInventoryService productInventoryService;
        private readonly IValidator<ProductInventory> validator;

        public ProductInventoryWebAPIController(IProductInventoryService productInventoryService, IValidator<ProductInventory> validator)
        {
            this.productInventoryService = productInventoryService;
            this.validator = validator;
        }

        [HttpGet]
        public object GetTypes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(Types.Type, loadOptions);
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

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return this.BadRequest(this.ModelState.ToFullErrorString());
            }

            this.productInventoryService.Add(model);

            return this.Ok();
        }

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var model = this.productInventoryService.GetAll().First(_ => _.ProductID == key);
            JsonConvert.PopulateObject(values, model);

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets("Update"));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return this.BadRequest(this.ModelState.ToFullErrorString());
            }

            this.productInventoryService.Update(model);

            return this.Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var model = this.productInventoryService.GetAll().First(_ => _.ProductID == key);

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets("Delete"));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return this.BadRequest(this.ModelState.ToFullErrorString());
            }

            this.productInventoryService.Delete(key);

            return this.Ok();
        }
    }
}
