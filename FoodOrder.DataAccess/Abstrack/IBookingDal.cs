using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.DataAccess.Abstrack
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
		void BookingStatusCancelled(int id);

	}
}
