﻿using FoodOrder.WebUI.Dtos.RestaurantTableDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodOrder.WebUI.Controllers
{
    public class RestaurantTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestaurantTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync("https://localhost:7026/api/RestaurantTables");
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateRestaurantTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurantTable(CreateRestaurantTableDto createRestaurantTableDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRestaurantTableDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7026/api/RestaurantTables", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }
        public async Task<IActionResult> DeleteRestaurantTable(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7026/api/RestaurantTables/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRestaurantTable(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7026/api/RestaurantTables/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateRestaurantTableDto>(jsonData);
                return View(value);

            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRestaurantTable(UpdateRestaurantTableDto updateRestaurantTableDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRestaurantTableDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7026/api/RestaurantTables/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync("https://localhost:7026/api/RestaurantTables");
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
