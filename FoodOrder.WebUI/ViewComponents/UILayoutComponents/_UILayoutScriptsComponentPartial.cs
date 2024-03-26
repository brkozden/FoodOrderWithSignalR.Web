using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
