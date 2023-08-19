using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Data
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public string NotificationText { get; set; } = string.Empty;
        public DateTime NotificationDate { get; set; }
        public Guid UserId { get; set; }
    }
}
