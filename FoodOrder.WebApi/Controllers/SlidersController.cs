﻿using FoodOrder.Business.Abstrack;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("SliderList")]
        public  IActionResult SliderList()
        {
            return Ok(_sliderService.TGetAll());
        }
    }
}
