using Email.Api.Models;

namespace Email.Api.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
