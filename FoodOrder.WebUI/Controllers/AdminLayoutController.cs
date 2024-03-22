using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
