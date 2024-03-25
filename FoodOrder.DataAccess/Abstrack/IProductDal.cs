using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();

        public int ProductCount();

        decimal ProductPriceAvg();

        decimal ProductPriceMin();

        decimal ProductPriceMax();

        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();


    }
}
