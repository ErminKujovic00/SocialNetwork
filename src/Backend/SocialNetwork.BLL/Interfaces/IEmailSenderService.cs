using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IEmailSenderService
    {
        Task sendEmailAsync(string name, string subject, string email, string message);
    }
}
