using FoodOrder.Business.Abstrack;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTablesController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;

        public RestaurantTablesController(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        [HttpGet("RestaurantTableCount")]
        public IActionResult RestaurantTableCount()
        {

            return Ok(_restaurantTableService.TRestaurantTableCount());

        }
    }
}
