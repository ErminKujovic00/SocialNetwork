using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        // GET: api/<NotificationController>
        [HttpGet]
        public IEnumerable<NotificationDTO> GetAll()
        {
            return _notificationService.GetNotifications();
        }

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public NotificationDTO Get(Guid id)
        {
            return _notificationService.GetNotification(id);
        }

        // POST api/<NotificationController>
        [HttpPost]
        public NotificationDTO Post(Guid id, string text, DateTime date, Guid UserId)
        {
            return _notificationService.AddNotification(id, text, date, UserId);
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public NotificationDTO? Put(Guid id, string text, DateTime date)
        {
            return _notificationService.UpdateNotification(id, text, date);
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public NotificationDTO? Delete(Guid id)
        {
            return _notificationService.DeleteNotification(id);
        }
    }
}
