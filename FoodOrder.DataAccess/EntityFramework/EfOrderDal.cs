using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(FoodOrderContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
          using var context = new FoodOrderContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new FoodOrderContext();
            return context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new FoodOrderContext();
            return context.Orders.Where(x=>x.Date==DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y=>y.TotalPrice);
        }

        public int TotalOrderCount()
        {
           using var context = new FoodOrderContext();
            return context.Orders.Count();
        }
    }
}
