using Blogger.WebApp.Models;

namespace Blogger.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmail(EmailData emailData);
    }
}
