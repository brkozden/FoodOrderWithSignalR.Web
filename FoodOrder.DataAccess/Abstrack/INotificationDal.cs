using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();

        List<Notification> GetNotificationByFalseLast4();

        List<Notification> GetAllNotificationByFalse();

        void NotificationChangeToTrue(int id);

        void NotificationChangeToFalse(int id);

    }
}
