using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
