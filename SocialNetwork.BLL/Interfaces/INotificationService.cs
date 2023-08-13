using SocialNetwork.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface INotificationService
    {
        IEnumerable<NotificationDTO> GetNotifications();

        NotificationDTO GetNotification(Guid id);

        NotificationDTO AddNotification(Guid id, string text, DateTime date, Guid UserId);

        NotificationDTO? UpdateNotification(Guid id, string text, DateTime date);

        NotificationDTO? DeleteNotification(Guid id);
    }
}
