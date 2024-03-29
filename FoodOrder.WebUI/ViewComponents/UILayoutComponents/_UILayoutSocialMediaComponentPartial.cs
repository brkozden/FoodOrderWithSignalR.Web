using FoodOrder.WebUI.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodOrder.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync("https://localhost:7026/api/SocialMedias");
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
