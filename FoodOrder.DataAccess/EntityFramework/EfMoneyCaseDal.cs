using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(FoodOrderContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new FoodOrderContext();
            var value = context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();

            return value;
        }
    }
}
