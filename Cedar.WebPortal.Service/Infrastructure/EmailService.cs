using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Ninject.Extensions.Logging;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Service.Common;

namespace Cedar.WebPortal.Service.Infrastructure
{
    public class EmailService : IEmailService
    {
        private ILogger _logger;

        public EmailService(ILogger logger)
        {
            this._logger = logger;
        }

        #region Implemented Interfaces

        #region IEmailService

        public void Send(MailMessage message)
        {
            bool b = (message.From.IsNull() || message.From.Address.IsNull() ||
                      !RegexUtilities.IsValidEmail(message.From.Address));
            bool b1 = (message.To.IsNull() || message.To.Count == 0 || message.To[0].Address.IsNull() ||
                       !RegexUtilities.IsValidEmail(message.To[0].Address));

            if (b || b1)
            {
                return;
            }

            //It so happen that the DEV certificates are invalid. Let the server callback when a certificate comes in
            ServicePointManager.ServerCertificateValidationCallback =
                (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new SmtpClient
                             {
                                 UseDefaultCredentials = false,
                                 DeliveryMethod = SmtpDeliveryMethod.Network,
                                 Credentials = new NetworkCredential("no-reply", "27654@xyz.ir"),
                                 Host = "mail.xyz.ir",
                                 EnableSsl = true,
                                 Port = 25,
                             };

            client.SendAsync(message, null);
            client.SendCompleted += ClientSendCompleted;
        }

        #endregion

        #endregion

        #region Methods

        private void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //TODO:
            if (e.Error != null)
            {
                _logger.Debug("An email {0} has been sent to customer", (e.Error == null ? " " : e.Error.ToString()));
            }
            else
            {
                _logger.Debug("An email {0} has been sent to customer", (e.UserState == null ? " " : e.UserState.ToString()));
            }
        }

        #endregion
    }
}