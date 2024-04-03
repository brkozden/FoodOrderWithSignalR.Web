using FoodOrder.WebUI.Dtos.BookingDtos;
using FoodOrder.WebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodOrder.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7026/api/Bookings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                CreateNotificationDto createNotificationDto = new()
                {
                    Date = DateTime.Now,
                    Description = "Bir Yeni Rezervasyonunuz Var",
                    Icon = "la la-cutlery",
                    Status = false,
                    Type = "notif-icon notif-success",



                };
                var notificationClient = _httpClientFactory.CreateClient();

                var createNotification = JsonConvert.SerializeObject(createNotificationDto);
                StringContent content = new StringContent(createNotification, Encoding.UTF8, "application/json");
                var responseNotificationMessage = await notificationClient.PostAsync("https://localhost:7026/api/Notifications", content);
                if (responseNotificationMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Default");

                }
                return View();

            }

            return NoContent();
        }
    }
}
