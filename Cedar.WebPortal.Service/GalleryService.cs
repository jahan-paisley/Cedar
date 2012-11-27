using System;
using System.Collections.Generic;
using System.Linq;
using Cedar.WebPortal.Data.Common;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Service.Common;
using Cedar.WebPortal.Service.Infrastructure;
using Cedar.WebPortal.Common;

namespace Cedar.WebPortal.Service
{
    public class GalleryService : ServiceBase<Gallery, IGalleryRepository>, IGalleryService
    {
        public virtual IAttachmentRepository attachmentRepository { get; set; }

        #region Constructors and Destructors

        public GalleryService(IGalleryRepository galleryRepository, IUnitOfWork unitOfWork,
                              IAttachmentRepository attachmentRepository)
            : base(galleryRepository, unitOfWork)
        {
            this.attachmentRepository = attachmentRepository;
        }

        #endregion

        #region Implemented Interfaces

        #region IGalleryService

        public Gallery GetPublishedGallery(Guid id)
        {
            Gallery gallery = GetById(id);
            return gallery;
        }

        public IEnumerable<Gallery> GetPublishedGallery()
        {
            IQueryable<Gallery> gallery = GetMany(o => o.Published);
            return gallery;
        }

        public IEnumerable<Gallery> GetUnpublishedGallery()
        {
            IQueryable<Gallery> gallery = GetMany(o => !o.Published);
            return gallery;
        }

        public IEnumerable<Gallery> GetGalleryForHomePage()
        {
            IQueryable<Gallery> gallery = GetMany(o => (o.Published && o.AppearInHomePage));
            return gallery;
        }

        public override IEnumerable<Gallery> GetAll()
        {
            IOrderedEnumerable<Gallery> gallery = base.GetAll().OrderByDescending(o => o.CaptureDate);
            return gallery;
        }

        public void DeleteById(Guid galleryId, Guid attachmentId)
        {
            var gallery = Repository.GetById(galleryId);
            Attachment attachment = gallery.Attachments.Where(p => p.AttachmentId == attachmentId).FirstOrDefault();
            gallery.Attachments.Remove(attachment);
            Repository.Save(gallery);
            attachmentRepository.Delete(attachmentId);
            this.UnitOfWork.Commit();
        }

        public void SaveIndividualAttachment(Guid galleryId, Attachment attachment)
        {

            attachmentRepository.Add(attachment);
            var gallery = Repository.GetById(galleryId);
            gallery.Attachments.Add(attachment);
            Repository.Save(gallery);
            this.UnitOfWork.Commit();
        }

        #endregion

        #endregion
    }
}