using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(FoodOrderContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new FoodOrderContext();
			var value = context.Bookings.Find(id);
			value.Description = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new FoodOrderContext();
			var value = context.Bookings.Find(id);
			value.Description = "İptal Edildi";
			context.SaveChanges();
		}
	}
}
