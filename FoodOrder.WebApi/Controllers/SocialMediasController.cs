﻿using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.SocialMediaDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetAll());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {

            _SocialMediaService.TAdd(new SocialMedia
            {
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon
            });
            return Ok("Sosyal Medya bilgisi başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {

            _SocialMediaService.TUpdate(new SocialMedia
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon
            });
            return Ok("Sosyal Medya bilgisi başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            _SocialMediaService.TDelete(value);
            return Ok("Sosyal Medya bilgisi başarılı bir şekilde silindi.");

        }
    }
}
