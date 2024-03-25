using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IRestaurantTableDal:IGenericDal<RestaurantTable>
    {
        int RestaurantTableCount();
    }
}
