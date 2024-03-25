using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetail;

        public OrderDetailManager(IOrderDetailDal orderDetail)
        {
            _orderDetail = orderDetail;
        }

        public void TAdd(OrderDetail entity)
        {
            _orderDetail.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetail.Delete(entity);
        }

        public List<OrderDetail> TGetAll()
        {
          return  _orderDetail.GetAll();
        }

        public OrderDetail TGetById(int id)
        {
           return _orderDetail.GetById(id);
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetail.Update(entity);
        }
    }
}
