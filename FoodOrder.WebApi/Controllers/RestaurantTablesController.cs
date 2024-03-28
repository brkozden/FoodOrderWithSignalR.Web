using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.RestaurantTableDto;
using FoodOrder.Entity.Entities;
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
        [HttpGet]
        public IActionResult RestaurantTableList()
        {
            var values = _restaurantTableService.TGetAll();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetRestaurantTable(int id)
        {
            var value = _restaurantTableService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateRestaurantTable(CreateRestaurantTableDto createRestaurantTableDto)
        {

            _restaurantTableService.TAdd(new RestaurantTable
            {

              Name = createRestaurantTableDto.Name,
              Status = createRestaurantTableDto.Status,
            });
            return Ok("Masa bilgisi başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateRestaurantTable(UpdateRestaurantTableDto updateRestaurantTableDto)
        {

            _restaurantTableService.TUpdate(new RestaurantTable
            {
                Name = updateRestaurantTableDto.Name,
                Status = updateRestaurantTableDto.Status,
                RestaurantTableId = updateRestaurantTableDto.RestaurantTableId,
            });
            return Ok("Masa bilgisi başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurantTable(int id)
        {
            var value = _restaurantTableService.TGetById(id);
            _restaurantTableService.TDelete(value);
            return Ok("Masa bilgisi başarılı bir şekilde silindi.");

        }

        [HttpGet("RestaurantTableCount")]
        public IActionResult RestaurantTableCount()
        {

            return Ok(_restaurantTableService.TRestaurantTableCount());

        }
    }
}
