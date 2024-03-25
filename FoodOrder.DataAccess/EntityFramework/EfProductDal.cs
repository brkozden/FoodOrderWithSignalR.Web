using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(FoodOrderContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new FoodOrderContext();
            return context.Products.Include(x => x.Category).ToList();
        }

        public int ProductCount()
        {
            var context = new FoodOrderContext();

            return context.Products.Count();
        }

        public string ProductNameByMaxPrice()
        {
            var context = new FoodOrderContext();

            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            var context = new FoodOrderContext();

            return context.Products.Where(x=>x.Price==(context.Products.Min(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            var context = new FoodOrderContext();
            return context.Products.Average(x => x.Price);
                }

        public decimal ProductPriceMax()
        {
            var context = new FoodOrderContext();
            return context.Products.Max(x => x.Price);
        }

        public decimal ProductPriceMin()
        {
            var context = new FoodOrderContext();
            return context.Products.Min(x => x.Price);
        }
    }
}
