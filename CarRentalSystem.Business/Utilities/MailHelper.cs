using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Utilities
{
    public static class MailHelper
    {
        
        public static Task<bool> SendMail(string mailTo,string subject, string mailBody) 
        {
            string sender = "carrental_11@outlook.com";
            MailMessage mailMessage = new MailMessage();

            mailMessage.Subject = subject;
            mailMessage.Body = mailBody;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.From = new MailAddress(sender,"Car Rental");
            mailMessage.To.Add(new MailAddress(mailTo));

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Credentials = new NetworkCredential(sender, "flyingmeatballaA");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.EnableSsl = true;
            
            try
            {
                smtpClient.SendAsync(mailMessage, (object)mailMessage);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
                
            }

        }

    }
}
