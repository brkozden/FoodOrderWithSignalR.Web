using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
