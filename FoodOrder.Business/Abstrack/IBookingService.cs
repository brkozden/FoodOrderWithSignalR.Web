using FoodOrder.EntityLayer.Entities;

namespace FoodOrder.Business.Abstrack
{
    public interface IBookingService:IGenericService<Booking>
    {
		void TBookingStatusApproved(int id);
		void TBookingStatusCancelled(int id);
	}
}
