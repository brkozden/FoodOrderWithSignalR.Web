using FoodOrder.Business.Abstrack;
using FoodOrder.Dto.NotificationDto;
using FoodOrder.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetNotificationListLast4")]
        public IActionResult GetNotificationListLast4()
        {
            return Ok(_notificationService.TGetNotificationByFalseLast4());
        }
        [HttpGet("GetAllNotificationList")]
        public IActionResult GetAllNotificationList()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {

            _notificationService.TAdd(new Notification
            {

                Icon = createNotificationDto.Icon,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false,
                Type = createNotificationDto.Type,
            });
            return Ok("Bildirim başarılı bir şekilde eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {

            _notificationService.TUpdate(new Notification
            {
                NotificationId = updateNotificationDto.NotificationId,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = updateNotificationDto.Status,
                Type = updateNotificationDto.Type,
            });
            return Ok("Bildirim başarılı bir şekilde güncellendi.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim başarılı bir şekilde silindi.");

        }
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("Bildirim Okundu Olarak İşaretlendi.");

        }
        [HttpGet("NotificationChangeToFalse/{id}")]
        public IActionResult NotificationChangeToFalse(int id)
        {
            _notificationService.TNotificationChangeToFalse(id);
            return Ok("Bildirim Okunmadı Olarak İşaretlendi.");

        }
    }
}
