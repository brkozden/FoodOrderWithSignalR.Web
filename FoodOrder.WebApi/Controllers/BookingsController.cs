using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.BookingDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
       
        private readonly IBookingService _BookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService BookingService, IMapper mapper)
        {
            _BookingService = BookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_BookingService.TGetAll());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {

            _BookingService.TAdd(new Booking
            {
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
            });
            return Ok("Kategori başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {

            _BookingService.TUpdate(new Booking
            {
                BookingId = updateBookingDto.BookingId,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
            });
            return Ok("Kategori başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            _BookingService.TDelete(value);
            return Ok("Kategori başarılı bir şekilde silindi.");

        }
    }
}
