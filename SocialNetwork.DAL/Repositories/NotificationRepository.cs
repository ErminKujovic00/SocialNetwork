using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SocialNetworkDBContext _dbContext;
        public NotificationRepository(SocialNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Notification> GetAllNotifications()
        {
            return _dbContext.Notifications.AsQueryable();
        }

        public Notification? GetSingleNotification(Guid id)
        {
            return _dbContext.Notifications.Where(x => x.NotificationId == id).FirstOrDefault();
        }

        public Notification AddSingleNotification(Guid notificationId, DateTime notificationDate, string notificationText, Guid userId)
        {
            Notification notification = new Notification
            {
                NotificationId = notificationId,
                NotificationDate = notificationDate,
                NotificationText = notificationText,
                UserId = userId
            };
            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();
            return notification;
        }

        public Notification? UpdateSingleNotification(Guid notificationId, DateTime notificationDate, string notificationText)
        {
            Notification? modifiedNotification = _dbContext.Notifications.Where(x => x.NotificationId.Equals(notificationId)).FirstOrDefault();
            if (modifiedNotification != null)
            {
                modifiedNotification.NotificationText = notificationText;
                modifiedNotification.NotificationDate = notificationDate;
                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new Exception();
                }
            }
            return modifiedNotification;
        }
        public Notification? DeleteSingleNotification(Guid id)
        {
            Notification? modifiedNotification = _dbContext.Notifications.Where(x => x.NotificationId.Equals(id)).FirstOrDefault();
            if (modifiedNotification != null)
            {
                _dbContext.Notifications.Remove(modifiedNotification);
                _dbContext.SaveChanges();
            }
            return modifiedNotification;
        }

    }
}
