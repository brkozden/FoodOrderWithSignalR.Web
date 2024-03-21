using AutoMapper;
using FoodOrder.Dto.ContactDto;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.WebApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
      
    }
}
