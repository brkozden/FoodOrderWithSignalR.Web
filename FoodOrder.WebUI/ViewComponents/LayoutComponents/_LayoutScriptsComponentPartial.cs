using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
