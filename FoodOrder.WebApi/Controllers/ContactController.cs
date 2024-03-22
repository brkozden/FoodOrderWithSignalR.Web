using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.ContactDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_ContactService.TGetAll());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            _ContactService.TAdd(new Contact
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone
            });
            return Ok("İletişim bilgisi başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {

            _ContactService.TUpdate(new Contact
            {
               ContactId = updateContactDto.ContactId,
               FooterDescription = updateContactDto.FooterDescription,
               Location = updateContactDto.Location,
               Mail = updateContactDto.Mail,
               Phone = updateContactDto.Phone
            });
            return Ok("İletişim bilgisi başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _ContactService.TGetById(id);
            _ContactService.TDelete(value);
            return Ok("İletişim bilgisi başarılı bir şekilde silindi.");

        }
    }
}
