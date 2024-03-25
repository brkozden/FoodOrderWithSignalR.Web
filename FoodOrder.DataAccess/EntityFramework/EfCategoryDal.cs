using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        
        public EfCategoryDal(FoodOrderContext context) : base(context)
        {

        }

        public int ActiveCategoryCount()
        {
            using var context = new FoodOrderContext();
            return context.Categories.Count(x=>x.Status.Equals(true));

        }

        public int CategoryCount()
        {
            using var context = new FoodOrderContext();
            return context.Categories.Count();
        }

        public string LastAddedCategoryName()
        {
            using var context = new FoodOrderContext();
            return context.Categories.OrderByDescending(x => x.CategoryId).Take(1).Select(y => y.CategoryName).FirstOrDefault();
        }

        public int PassiveCategoryCount()
        {
            using var context = new FoodOrderContext();
            return context.Categories.Count(x => x.Status.Equals(false));
        }
    }
}
