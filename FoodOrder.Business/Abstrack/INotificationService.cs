using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();

        List<Notification> TGetNotificationByFalseLast4();
        List<Notification> TGetAllNotificationByFalse();
        void TNotificationChangeToTrue(int id);
        void TNotificationChangeToFalse(int id);

    }
}
