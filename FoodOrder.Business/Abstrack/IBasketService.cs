using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);

    }
}
