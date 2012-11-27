using Cedar.WebPortal.Domain;

namespace Cedar.WebPortal.Service.Common
{
    using System;
    using System.Collections.Generic;

    using Cedar.WebPortal.Domain;

    public interface IGalleryService : IServiceBase<Gallery>
    {
        #region Public Methods

        IEnumerable<Gallery> GetPublishedGallery();

        IEnumerable<Gallery> GetGalleryForHomePage();

        Gallery GetPublishedGallery(Guid id);

        IEnumerable<Gallery> GetUnpublishedGallery();

        void DeleteById(Guid galleryId, Guid attachmentId);

        void SaveIndividualAttachment(Guid galleryId, Attachment attachment);

        #endregion
    }
}