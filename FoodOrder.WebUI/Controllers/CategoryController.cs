﻿using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
