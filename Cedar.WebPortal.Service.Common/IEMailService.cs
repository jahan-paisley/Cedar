namespace Cedar.WebPortal.Service.Common
{
    using System.Net.Mail;

    public interface IEmailService
    {
        void Send(MailMessage message);
    }

}