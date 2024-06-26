﻿using FoodOrder.WebUI.Dtos.BookingDtos;
using FoodOrder.WebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodOrder.WebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMesssage = await client.GetAsync("https://localhost:7026/api/Bookings");
			if (responseMesssage.IsSuccessStatusCode)
			{
				var jsonData = await responseMesssage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateBooking()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
		{
			var client = _httpClientFactory.CreateClient();
			createBookingDto.Description = "Rezervasyon Alındı";
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
                    return RedirectToAction("Index");

                }
                return View();

            }

			return View();
		}
		public async Task<IActionResult> RemoveBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.DeleteAsync("https://localhost:7026/api/Bookings/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:7026/api/Bookings/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(value);

			}

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var client = _httpClientFactory.CreateClient();
			updateBookingDto.Description = "Rezervasyon Alındı";
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7026/api/Bookings/", content);
			if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");

			}
			return View();
		}
	
		public  async Task<IActionResult> BookingStatusApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();

			await client.GetAsync($"https://localhost:7026/api/Bookings/BookingStatusApproved/{id}");
			
				return RedirectToAction("Index");

			

		
		}


		public   async Task<IActionResult> BookingStatusCancelled(int id)
		{
			var client = _httpClientFactory.CreateClient();

		 await  client.GetAsync("https://localhost:7026/api/Bookings/BookingStatusCancelled/" + id);
			
				return RedirectToAction("Index");

		}
	}
}
