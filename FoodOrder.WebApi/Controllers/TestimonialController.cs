using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.TestimonialDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _TestimonialService = TestimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_TestimonialService.TGetAll());
            return Ok(values);

        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _TestimonialService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            _TestimonialService.TAdd(new Testimonial
            {
                Title = createTestimonialDto.Title,
                Name = createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = createTestimonialDto.Status,
            });
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {

            _TestimonialService.TUpdate(new Testimonial
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
               Title = updateTestimonialDto.Title,
               Name = updateTestimonialDto.Name,
               Comment = updateTestimonialDto.Comment,
               ImageUrl = updateTestimonialDto.ImageUrl,
               Status = updateTestimonialDto.Status
               
            });
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde güncellendi.");

        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(value);
            return Ok("Müşteri yorum bilgisi başarılı bir şekilde silindi.");

        }
    }
}
