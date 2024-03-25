using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfRestaurantTableDal : GenericRepository<RestaurantTable>, IRestaurantTableDal
    {
        public EfRestaurantTableDal(FoodOrderContext context) : base(context)
        {
        }

        public int RestaurantTableCount()
        {
            using var context = new FoodOrderContext();
            return context.RestaurantTables.Count();
        }
    }
}
