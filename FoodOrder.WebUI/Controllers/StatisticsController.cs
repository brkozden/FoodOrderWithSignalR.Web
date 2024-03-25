using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
