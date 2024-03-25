using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface ICategoryService:IGenericService<Category>
    {
         int TCategoryCount();
        int TActiveCategoryCount();
        int TPassiveCategoryCount();

        string TLastAddedCategoryName();
    }
}
