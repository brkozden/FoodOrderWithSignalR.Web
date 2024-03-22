using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
