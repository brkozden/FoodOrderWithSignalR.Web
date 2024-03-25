using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
         int TProductCount();

        decimal TProductPriceAvg();
        decimal TProductPriceMin();

        decimal TProductPriceMax();

        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();


    }
}
