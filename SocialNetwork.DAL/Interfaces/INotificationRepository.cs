using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAllNotifications();

        Notification? GetSingleNotification(Guid id);

        Notification AddSingleNotification(Guid notificationId, DateTime notificationDate, string notificationText, Guid userId);

        Notification? UpdateSingleNotification(Guid notificationId, DateTime notificationDate, string notificationText);

        Notification? DeleteSingleNotification(Guid id);
    }
}
