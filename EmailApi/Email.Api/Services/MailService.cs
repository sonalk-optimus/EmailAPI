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
                // Mistake 1: Hardcoded SMTP server and port instead of using config
                SmtpClient smtpServer = new SmtpClient("in-v3.mailjet.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    // Mistake 2: Hardcoded credentials (should be from config or secure vault)
                    Credentials = new NetworkCredential("745752d3e4dbaf360f9b83da", "8747b2b74209ab9144a7a4"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 60000,
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("sonal.khatri@optimusinfo.com", "MailDelivery")
                };

                // Mistake 3: No null or format validation on recipient email
                mailMessage.To.Add(mailRequest.RecipientEmailAddress);

                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                // Mistake 4: No input validation on email body, vulnerable to null or injection
                mailMessage.Body = mailRequest.Body;
                mailMessage.IsBodyHtml = true;

                // Mistake 5: Synchronous send instead of async SendMailAsync
                smtpServer.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Mistake 6: Re-throwing exception without preserving stack trace (just throw; is better)
                throw ex;
            }
        }
    }
}
