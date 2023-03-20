using Microsoft.AspNetCore.Mvc;

namespace Inventory.Product.API.Controllers
{
    public class InventoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
