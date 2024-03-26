using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
