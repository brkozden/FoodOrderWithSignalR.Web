using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
          
            return Ok(_OrderService.TTotalOrderCount());

        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {

            return Ok(_OrderService.TActiveOrderCount());

        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {

            return Ok(_OrderService.TLastOrderPrice());

        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {

            return Ok(_OrderService.TTodayTotalPrice());

        }

    }
}
