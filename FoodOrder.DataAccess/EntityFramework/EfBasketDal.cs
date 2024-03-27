using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(FoodOrderContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new FoodOrderContext();
            return context.Baskets.Where(x=>x.RestaurantTableId == id).Include(y=>y.Product).ToList();
        }
    }
}
