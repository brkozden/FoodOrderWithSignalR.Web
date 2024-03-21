using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.DiscountDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService DiscountService, IMapper mapper)
        {
            _DiscountService = DiscountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_DiscountService.TGetAll());
            return Ok(values);

        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _DiscountService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            _DiscountService.TAdd(new Discount
            {
                Title = createDiscountDto.Title,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Amount = createDiscountDto.Amount
            });
            return Ok("İndirim başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {

            _DiscountService.TUpdate(new Discount
            {
                DiscountId = updateDiscountDto.DiscountId,
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Amount = updateDiscountDto.Amount
            });
            return Ok("İndirim başarılı bir şekilde güncellendi.");

        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _DiscountService.TGetById(id);
            _DiscountService.TDelete(value);
            return Ok("İndirim başarılı bir şekilde silindi.");

        }
    }
}
