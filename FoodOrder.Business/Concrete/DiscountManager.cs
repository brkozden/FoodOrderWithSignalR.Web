using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> TGetAll()
        {
           return _discountDal.GetAll();
        }

        public Discount TGetById(int id)
        {
          return  _discountDal.GetById(id);
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
