using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
