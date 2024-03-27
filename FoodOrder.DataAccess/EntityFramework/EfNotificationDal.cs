using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.Entity.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(FoodOrderContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new FoodOrderContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public List<Notification> GetNotificationByFalseLast4()
        {
            using var context = new FoodOrderContext();
            return context.Notifications.OrderByDescending(x => x.NotificationId).Where(y=>y.Status==false).Take(4).ToList();
        }

        public void NotificationChangeToFalse(int id)
        {
            using var context = new FoodOrderContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationChangeToTrue(int id)
        {
            using var context = new FoodOrderContext();
            var value = context.Notifications.Find(id);
            value.Status =true;
            context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new FoodOrderContext();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }
    }
}
