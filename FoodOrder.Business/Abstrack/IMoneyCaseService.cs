using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface IMoneyCaseService:IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();
    }
}
