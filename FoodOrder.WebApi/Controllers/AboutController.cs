using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.AboutDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
       
      private readonly IAboutService _AboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService AboutService, IMapper mapper)
        {
            _AboutService = AboutService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_AboutService.TGetAll());
            return Ok(values);

        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _AboutService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {

            _AboutService.TAdd(new About
            {
              
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            });
            return Ok("Hakkında bilgisi başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {

            _AboutService.TUpdate(new About
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
            });
            return Ok("Hakkında bilgisi başarılı bir şekilde güncellendi.");

        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _AboutService.TGetById(id);
            _AboutService.TDelete(value);
            return Ok("Hakkında bilgisi başarılı bir şekilde silindi.");

        }
    }
}
