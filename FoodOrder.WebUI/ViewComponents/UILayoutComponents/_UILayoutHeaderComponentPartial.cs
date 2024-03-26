using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
