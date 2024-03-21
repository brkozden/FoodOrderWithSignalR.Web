using AutoMapper;
using FoodOrder.Dto.AboutDto;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.WebApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();

        }
    }
}
