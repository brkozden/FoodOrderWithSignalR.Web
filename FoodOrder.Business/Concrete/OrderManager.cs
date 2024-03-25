using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Concrete
{

    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
           return _orderDal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
          _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
           _orderDal.Delete(entity);
        }

        public List<Order> TGetAll()
        {
           return _orderDal.GetAll();
        }

        public Order TGetById(int id)
        {
           return _orderDal.GetById(id);
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
          _orderDal.Update(entity);
        }
    }
}
