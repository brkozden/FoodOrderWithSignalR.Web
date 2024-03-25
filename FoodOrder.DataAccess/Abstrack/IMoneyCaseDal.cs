using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IMoneyCaseDal:IGenericDal<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
