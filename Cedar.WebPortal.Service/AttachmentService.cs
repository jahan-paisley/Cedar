using System.Collections.Generic;
using System.Linq;
using Cedar.WebPortal.Data.Common;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Domain.Entities;
using Cedar.WebPortal.Service.Common;
using Cedar.WebPortal.Service.Infrastructure;

namespace Cedar.WebPortal.Service
{
    public class AttachmentService : ServiceBase<Attachment, IAttachmentRepository>, IAttachmentService
    {
        #region Constructors and Destructors

        public AttachmentService(IAttachmentRepository attachmentRepository, IUnitOfWork unitOfWork)
            : base(attachmentRepository, unitOfWork)
        {
        }

        #endregion

        #region IAttachmentService Members

        public IEnumerable<Attachment> GetPictureGallery()
        {
            IQueryable<Attachment> attchment = GetMany(o => o.Tag == "PictureGallery");
            return attchment;
        }

        #endregion
    }
}