using System;
using System.Collections.Generic;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Data.Common;
using Cedar.WebPortal.Data.Infrastructure;
using Cedar.WebPortal.Domain;

namespace Cedar.WebPortal.Data
{
    public class GalleryRepository : RepositoryBase<Gallery>, IGalleryRepository
    {
        private IAttachmentRepository attachmentRepository;

        #region Constructors and Destructors

        public GalleryRepository(IDatabaseFactory databaseFactory, IAttachmentRepository attachmentRepository)
            : base(databaseFactory)
        {
            this.attachmentRepository = attachmentRepository;
        }

        #endregion

        protected override void BeforeSave(Gallery arg)
        {
            CheckIfAFileWasSent(arg, arg.Attachments);
        }

        /// <summary>
        /// Update the attachment only if a file was sent and it's different from original one
        /// </summary>
        /// <param name="gallery"></param>
        /// <param name="attachments"></param>
        private void CheckIfAFileWasSent(Gallery gallery, IList<Attachment> attachments)
        {
            //File already exists in db but another file has been sent now, so the databse should be updated
            foreach (Attachment attachment in attachments)
            {
                if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty &&
                    attachment.ContentLength > 0)
                {
                    DataContext.Get<Attachment>(attachment.AttachmentId);
                }
                //file already exist and nothing was sent by user
                if (attachment.IsNotNull() && attachment.AttachmentId != Guid.Empty &&
                    !attachment.ContentLength.HasValue)
                {
                    gallery.Attachments.Add(DataContext.Get<Attachment>(attachment.AttachmentId));
                }
            }
        }
    }
}