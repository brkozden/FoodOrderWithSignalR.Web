using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
           _sliderDal.Delete(entity);
        }

        public List<Slider> TGetAll()
        {
           return _sliderDal.GetAll();
        }

        public Slider TGetById(int id)
        {
           return _sliderDal.GetById(id);
        }

        public void TUpdate(Slider entity)
        {
           _sliderDal.Update(entity);
        }
    }
}
