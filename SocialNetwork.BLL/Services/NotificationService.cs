using AutoMapper;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public IEnumerable<NotificationDTO> GetNotifications()
        {
            IEnumerable<Notification> notifications = _notificationRepository.GetAllNotifications();
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }
        public NotificationDTO GetNotification(Guid id)
        {
            return _mapper.Map<NotificationDTO>(_notificationRepository.GetSingleNotification(id));
        }

        public NotificationDTO AddNotification(Guid id, string text, DateTime date, Guid UserId)
        {
            Notification? notification = _notificationRepository.AddSingleNotification(id, date, text, UserId);
            return _mapper.Map<NotificationDTO>(notification);
        }
        public NotificationDTO? UpdateNotification(Guid id, string text, DateTime date)
        {
            Notification? notification = _notificationRepository.UpdateSingleNotification(id, date, text);
            return _mapper.Map<NotificationDTO>(notification);
        }

        public NotificationDTO? DeleteNotification(Guid id)
        {
            Notification? notification = _notificationRepository.DeleteSingleNotification(id);
            return _mapper.Map<NotificationDTO>(notification);
        }


    }
}
