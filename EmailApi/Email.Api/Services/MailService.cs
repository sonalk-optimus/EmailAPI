using Email.Api.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace Email.Api.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(MailRequest mailRequest)
        {
            try
            {
                SmtpClient smtpServer = new SmtpClient("in-v3.mailjet.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("745752d3e4dbaf360f9b83da4e7577ac", "8747b2b74209ab9144a7a4b9111cecb3"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 60000,

                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("sonal.khatri@optimusinfo.com", "MailDelivery")
                };
                mailMessage.To.Add(mailRequest.RecipientEmailAddress);
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mailMessage.Body = mailRequest.Body;
                mailMessage.IsBodyHtml = true;
                smtpServer.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }       
}
