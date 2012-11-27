using System.Collections.Generic;

namespace Cedar.WebPortal.Service.Common
{
    using Cedar.WebPortal.Domain;

    public interface IAttachmentService: IServiceBase<Attachment>
    {
        IEnumerable<Attachment> GetPictureGallery();
    }
}