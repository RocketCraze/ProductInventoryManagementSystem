using Microsoft.AspNetCore.Mvc;

namespace ProductInventoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
