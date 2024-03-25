using AutoMapper;
using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.Dto.ProductDto;
using FoodOrder.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetAll());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(value);

        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {

            return Ok(_ProductService.TProductCount());

        }
        [HttpGet("ProductPriceMin")]
        public IActionResult ProductPriceMin()
        {

            return Ok(_ProductService.TProductPriceMin());

        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {

            return Ok(_ProductService.TProductPriceAvg());

        }
        [HttpGet("ProductPriceMax")]
        public IActionResult ProductPriceMax()
        {

            return Ok(_ProductService.TProductPriceMax());

        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {

            return Ok(_ProductService.TProductNameByMinPrice());

        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {

            return Ok(_ProductService.TProductNameByMaxPrice());

        }
        [HttpGet("GetProductsWithCategory")]
        public IActionResult GetProductsWithCategory()
        {
            var context = new FoodOrderContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Status = y.Status,
                Description = y.Description,
                CategoryName = y.Category.CategoryName,

            }).ToList();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            _ProductService.TAdd(new Product
            {
                ProductName = createProductDto.ProductName,
                Status = createProductDto.Status,
                ImageUrl = createProductDto.ImageUrl,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                CategoryId = createProductDto.CategoryId,
            });
            return Ok("Ürün başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {

            _ProductService.TUpdate(new Product
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                Status = updateProductDto.Status,
                ImageUrl = updateProductDto.ImageUrl,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                CategoryId = updateProductDto.CategoryId,
            });
            return Ok("Ürün başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            _ProductService.TDelete(value);
            return Ok("Ürün başarılı bir şekilde silindi.");

        }
    }
}
