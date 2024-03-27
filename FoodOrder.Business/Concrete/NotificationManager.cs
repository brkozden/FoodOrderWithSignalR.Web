using FoodOrder.Business.Abstrack;
using FoodOrder.DataAccess.Abstrack;
using FoodOrder.Entity.Entities;

namespace FoodOrder.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();   
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
            return _notificationDal.GetAllNotificationByFalse();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetNotificationByFalseLast4()
        {
            return _notificationDal.GetNotificationByFalseLast4();
        }

        public void TNotificationChangeToFalse(int id)
        {
            _notificationDal.NotificationChangeToFalse(id);
        }

        public void TNotificationChangeToTrue(int id)
        {
            _notificationDal.NotificationChangeToTrue(id);
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
