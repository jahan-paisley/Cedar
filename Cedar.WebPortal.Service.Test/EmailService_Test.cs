namespace Cedar.WebPortal.Service.Test
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Mail;
    using Xunit;

    public class EmailService_Test
    {
        [Fact]
        public void Send_eMail_Test()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                          (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new SmtpClient
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("no-reply", "27654@rightel.ir"),
                Host = "mail.rightel.ir",
                EnableSsl = true,
                Port = 25,
            };
            MailMessage message = new MailMessage
            {
                From = new MailAddress("no-reply@rightel.ir"),
            };
            message.To.Add(new MailAddress("jzinedine@gmail.com"));
            message.Subject = "subject";
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            message.Body = "salam";
            client.SendCompleted += ClientSendCompleted;
            client.SendAsync(message, null);
        }

        private void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Trace.Write("sent");
        }
    }
}
