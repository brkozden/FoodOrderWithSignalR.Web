using AutoMapper;
using FoodOrder.Dto.ProductDto;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.WebApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
        }

    }
}
