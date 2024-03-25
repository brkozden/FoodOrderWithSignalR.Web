using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface IRestaurantTableService:IGenericService<RestaurantTable>
    {
        int TRestaurantTableCount();
    }
}
