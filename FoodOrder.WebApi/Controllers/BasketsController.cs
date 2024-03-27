using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.Dto.BasketDto;
using FoodOrder.Entity.Entities;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByMenuTableNumber/{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);

        }
        [HttpGet("GetBasketByMenuTableNumberWithProductName/{id}")]
        public IActionResult GetBasketByMenuTableNumberWithProductName(int id)
        {
            using var context = new FoodOrderContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.RestaurantTableId == id)
                .Select(z => new ResultBasketWithProducts
                {
                    RestaurantTableId = z.RestaurantTableId,
                    BasketId = z.BasketId,
                    Count = z.Count,
                    Price = z.Price,
                    ProductId = z.ProductId,
                    ProductName = z.Product.ProductName,
                    TotalPrice = z.TotalPrice,
                    CategoryName = z.Product.Category.CategoryName,
                    ImageUrl = z.Product.ImageUrl,
                    


                }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new FoodOrderContext();
            _basketService.TAdd(new Basket
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                RestaurantTableId = 1,
                Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0,
            });


            return Ok("Sepet başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveProductFromBasket(int id)
        {

            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki ürün başarılı bir şekilde silindi.");

      
        }
    }
}