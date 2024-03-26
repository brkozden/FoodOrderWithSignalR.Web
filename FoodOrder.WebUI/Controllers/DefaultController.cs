using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
