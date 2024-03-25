using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface ICategoryDal:IGenericDal<Category>
    {
         int CategoryCount();

        
        string LastAddedCategoryName();
         int ActiveCategoryCount();
         int PassiveCategoryCount();

    }
}
