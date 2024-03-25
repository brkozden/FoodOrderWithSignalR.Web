using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Concrete
{
    public class RestaurantTableManager : IRestaurantTableService
    {
        private readonly IRestaurantTableDal _restaurantTableDal;

        public RestaurantTableManager(IRestaurantTableDal restaurantTableDal)
        {
            _restaurantTableDal = restaurantTableDal;
        }

        public void TAdd(RestaurantTable entity)
        {
            _restaurantTableDal.Add(entity);
        }

        public void TDelete(RestaurantTable entity)
        {
            _restaurantTableDal.Delete(entity);
        }

        public List<RestaurantTable> TGetAll()
        {
            return _restaurantTableDal.GetAll();
        }

        public RestaurantTable TGetById(int id)
        {
          return _restaurantTableDal.GetById(id);
        }

        public int TRestaurantTableCount()
        {
            return _restaurantTableDal.RestaurantTableCount();
        }

        public void TUpdate(RestaurantTable entity)
        {
           _restaurantTableDal.Update(entity);
        }
    }
}
