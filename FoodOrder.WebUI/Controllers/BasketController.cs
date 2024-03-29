using FoodOrder.WebUI.Dtos.BasketDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodOrder.WebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync("https://localhost:7026/api/Baskets/GetBasketByMenuTableNumberWithProductName/1");
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                int productCount = values.Count();
                ViewBag.productCount = productCount;
                return View(values);
            }
            return View();
        }
      
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7026/api/Baskets/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return NoContent();
        }

    }
}
