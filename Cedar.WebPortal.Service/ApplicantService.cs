using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NPOI.HSSF.Record.Formula.Functions;
using System.Linq;

namespace Cedar.WebPortal.Service
{
    using System.IO;
    using System.Net.Mail;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.Service.Infrastructure;

    using Attachment = System.Net.Mail.Attachment;

    public class ApplicantService : ServiceBase<Applicant, IApplicantRepository>, IApplicantService
    {
        #region Constants and Fields

        private readonly IEmailService emailService;

        #endregion

        #region Constructors and Destructors

        public ApplicantService(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IEmailService emailService)
            : base(applicantRepository, unitOfWork)
        {
            this.emailService = emailService;
        }

        #endregion

        #region Implemented Interfaces

        #region IApplicantService

        public string CreateApplicant(Applicant applicant)
        {
            applicant.FollowupCode = this.GenerateFollowupCode();
            this.Add(applicant);
            return applicant.FollowupCode;
        }

        public string GenerateFollowupCode()
        {
            return Repository.GenerateFollowupCode();
        }

        public void SendMail(Applicant applicant, string body)
        {
            if (string.IsNullOrEmpty(applicant.EMail) || !RegexUtilities.IsValidEmail(applicant.EMail))
            {
                return;
            }

            var mailMessage = new MailMessage();
            mailMessage.To.Add(applicant.EMail); /*TODO: someone from HR*/
            mailMessage.From = new MailAddress("no-reply@rightel.ir");
            mailMessage.Body = body;
            mailMessage.Subject = "Confirmation Mail";
            mailMessage.IsBodyHtml = true;
            if (applicant.CV.IsNotNull() && applicant.CV.Contents.IsNotNull())
            {
                mailMessage.Attachments.Add(
                    new Attachment(new MemoryStream(applicant.CV.Contents), applicant.CV.ContentType)
                        {
                            Name = applicant.CV.FileName
                        });
            }
            this.emailService.Send(mailMessage);
        }

        public IEnumerable<Applicant> DynamicQuery<TValue>(TValue value, Expression<Func<Applicant, bool>> predicate)
        {
            return GetMany(predicate);
        }

        #endregion

        #endregion
    }
}