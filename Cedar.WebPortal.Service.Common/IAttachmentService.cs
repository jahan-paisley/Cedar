using System.Collections.Generic;

namespace Cedar.WebPortal.Service.Common
{
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Entities;

    public interface IAttachmentService: IServiceBase<Attachment>
    {
        IEnumerable<Attachment> GetPictureGallery();
    }
}