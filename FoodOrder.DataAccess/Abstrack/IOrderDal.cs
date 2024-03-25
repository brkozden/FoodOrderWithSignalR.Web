using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IOrderDal:IGenericDal<Order>
    {
        int TotalOrderCount();

        int ActiveOrderCount();

        decimal LastOrderPrice();
        decimal TodayTotalPrice();
    }
}
