namespace Cedar.WebPortal.Data
{
    using System;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        #region Constructors and Destructors

        public NewsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        protected override void BeforeSave(News prospect)
        {
            this.CheckIfAFileWasSent(prospect, prospect.Attachment);
        }

        /// <summary>
        /// Update the attachment only if a file was sent and it's different from original one
        /// </summary>
        /// <param name="news"></param>
        /// <param name="attachment"></param>
        private void CheckIfAFileWasSent(News news, Attachment attachment)
        {
            //File already exists in db but another file has been sent now, so the databse should be updated
            if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty &&
                attachment.ContentLength > 0)
            {
                this.DataContext.Get<Attachment>(attachment.AttachmentId);
            }

            //file already exist and nothing was sent by user
            if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty &&
                !attachment.ContentLength.HasValue)
            {
                news.Attachment = this.DataContext.Get<Attachment>(attachment.AttachmentId);
            }
        }
    }
}