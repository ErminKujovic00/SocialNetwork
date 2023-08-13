using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Data
{
    public class NotificationDTO
    {
        public string NotificationText { get; set; } = string.Empty;
        public DateTime NotificationDate { get; set; }
    }
}
