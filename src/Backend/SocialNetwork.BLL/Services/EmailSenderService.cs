using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task sendEmailAsync(string name, string subject, string email, string message)
        {

            var mail = "erminkujovic@hotmail.com";
            var pw = "pinkilinki123";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };
            /*
             * Pošaljem mail sam sebi sa user mailom u subject u slučaju da treba da ih kontaktiram.
             */
            return client.SendMailAsync(  //treba skontat kako obezbijedit u slucaju neuspjeha
                new MailMessage(from: mail,
                                to: mail,
                                subject + " " + email,
                                name + ",\n" + message)); 
        }
    }
}
