namespace Cedar.WebPortal.Data
{
    using System;
    using System.Linq;

    using NHibernate.Linq;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class ApplicantRepository : RepositoryBase<Applicant>, IApplicantRepository
    {
        #region Constructors and Destructors

        public ApplicantRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        #region Implemented Interfaces

        #region IApplicantRepository

        public string GenerateFollowupCode()
        {
            string followupCode = Guid.NewGuid().GetHashCode().ToString().Replace("-", "");
            int count = this.DataContext.Query<Applicant>().Count(o => o.FollowupCode == followupCode);
            return count > 0 ? this.GenerateFollowupCode() : followupCode;
        }

        #endregion

        #region IRepository<Applicant>

        public override void Add(Applicant entity)
        {
            entity.ApplicationDate = DateTime.Now;
            base.Add(entity);
        }

        #endregion

        #endregion

        #region Methods

        protected override void BeforeSave(Applicant applicant)
        {
            //applicant.EducationInfos.ForEach(o => o.Applicant = applicant);
            applicant.Publications.ForEach(o => o.Applicant = applicant);
            applicant.Certificates.ForEach(o => o.Applicant = applicant);
            applicant.HabitationInfos.ForEach(o => o.Applicant = applicant);
            applicant.LanguageSkills.ForEach(o => o.Applicant = applicant);
            applicant.Skills.ForEach(o => o.Applicant = applicant);
            applicant.Relatives.ForEach(o => o.Applicant = applicant);
            applicant.WorkExperienceInfos.ForEach(o => o.Applicant = applicant);

            this.CheckIfAFileWasSent(applicant, applicant.Item(o => o.Picture));
            this.CheckIfAFileWasSent(applicant, applicant.Item(o => o.CV));
            this.CheckIfAFileWasSent(applicant, applicant.Item(o=> o.EnglishCV));
        }

        private void CheckIfAFileWasSent(Applicant applicant, string propname)
        {
            //File already exists in db but another file has been sent now, so the databse should be updated
            var attachment = applicant.GetProperty<Applicant, Attachment>(propname);
            if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty && attachment.ContentLength > 0)
            {
                this.DataContext.Get<Attachment>(attachment.AttachmentId);
            }

            //file already exist and nothing was sent by user
            if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty && !attachment.ContentLength.HasValue)
            {
                applicant.SetProperty(propname, this.DataContext.Get<Attachment>(attachment.AttachmentId));
            }
        }

        #endregion
    }
}