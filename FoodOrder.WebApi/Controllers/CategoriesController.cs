using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.CategoryDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_CategoryService.TGetAll());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _CategoryService.TGetById(id);
            return Ok(value);

        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
           
            return Ok(_CategoryService.TCategoryCount());

        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {

            return Ok(_CategoryService.TActiveCategoryCount());

        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {

            return Ok(_CategoryService.TPassiveCategoryCount());

        }
        [HttpGet("LastAddedCategoryName")]
        public IActionResult LastAddedCategoryName()
        {

            return Ok(_CategoryService.TLastAddedCategoryName());

        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            
            _CategoryService.TAdd(new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status,
            });
            return Ok("Kategori başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
           
            _CategoryService.TUpdate(new Category
            {
                CategoryId = updateCategoryDto.CategoryId,
                CategoryName = updateCategoryDto.CategoryName,
                Status = updateCategoryDto.Status,
            });
            return Ok("Kategori başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _CategoryService.TGetById(id);
            _CategoryService.TDelete(value);
            return Ok("Kategori başarılı bir şekilde silindi.");

        }
    }
}
