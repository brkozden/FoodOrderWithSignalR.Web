using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
