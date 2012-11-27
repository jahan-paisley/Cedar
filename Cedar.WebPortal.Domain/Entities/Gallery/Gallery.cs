using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Cedar.WebPortal.Domain.Component;
using Cedar.WebPortal.Domain.Resources;

namespace Cedar.WebPortal.Domain
{
    public class Gallery
    {
        #region Constructors and Destructors

        public Gallery()
        {
            this.Attachments=new List<Attachment>();
            this.CaptureDate = DateTime.Now;
            this.PublishDate = DateTime.Now;
        }

        #endregion

        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_Attachment")]
        public virtual IList<Attachment> Attachments { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_CaptureDate")]
        public virtual DateTime CaptureDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_Code")]
        public virtual long Code { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_Contents")]
        public virtual string Contents { get; set; }

        public virtual User CreatorUser { get; set; }

        public virtual Guid GalleryId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_PublishDate")]
        public virtual DateTime PublishDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_Published")]
        public virtual bool Published { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_AppearInHomePage")]
        public virtual bool AppearInHomePage { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Gallery_Title")]
        public virtual string Title { get; set; }

        #endregion

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(Gallery))
            {
                return false;
            }
            return this.Equals((Gallery)obj);
        }

        protected virtual bool Equals(Gallery other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Attachments, this.Attachments) && other.CaptureDate.Equals(this.CaptureDate) &&
                   other.Code == this.Code && Equals(other.Contents, this.Contents) && other.GalleryId.Equals(this.GalleryId) &&
                   other.PublishDate.Equals(this.PublishDate) && other.Published.Equals(this.Published) &&
                   Equals(other.Title, this.Title);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (this.Attachments != null ? this.Attachments.GetHashCode() : 0);
                result = (result * 397) ^ this.CaptureDate.GetHashCode();
                result = (result * 397) ^ this.Code.GetHashCode();
                result = (result * 397) ^ (this.Contents != null ? this.Contents.GetHashCode() : 0);
                result = (result * 397) ^ this.GalleryId.GetHashCode();
                result = (result * 397) ^ this.PublishDate.GetHashCode();
                result = (result * 397) ^ this.Published.GetHashCode();
                result = (result * 397) ^ (this.Title != null ? this.Title.GetHashCode() : 0);
                return result;
            }
        }

        #endregion
    }
}