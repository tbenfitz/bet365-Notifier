using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Threading.Tasks;

namespace bet365_Notifier
{
    public class EmailHelper
    {
        public void SendNotificationEmail(string emailTo, string subject, string mailText)
        {         
            try
            {
                string smtpServer = "smtp.gmail.com";

                string smtpUsername = "bet365.gamenotifier@gmail.com";
                string smtpPassword = "";                

                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add(emailTo);
                
                mailMessage.From = new MailAddress("bet365.gamenotifier@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = mailText;

                SmtpClient smtpClient;

                smtpClient = new SmtpClient();

                NetworkCredential netCred =
                    new NetworkCredential(smtpUsername, smtpPassword);

                smtpClient.Host = smtpServer;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = netCred;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;            

                smtpClient.Send(mailMessage);                
            }
            catch (Exception ex)
            {
                int a = 0;
            }
        }

        public void SendExceptionEmail(string exceptionInfo)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";

                string smtpUsername = "bet365.gamenotifier@gmail.com";
                string smtpPassword = "";

                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add("tbenfitz@gmail.com");

                mailMessage.From = new MailAddress("bet365.gamenotifier@gmail.com");
                mailMessage.Subject = "bet365 - Exception";
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = exceptionInfo;

                SmtpClient smtpClient;

                smtpClient = new SmtpClient();

                NetworkCredential netCred =
                    new NetworkCredential(smtpUsername, smtpPassword);

                smtpClient.Host = smtpServer;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = netCred;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                int a = 0;
            }
        }
    }
}
