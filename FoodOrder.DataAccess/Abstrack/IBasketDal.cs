using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
