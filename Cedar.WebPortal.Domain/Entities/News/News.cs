namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Enums;
    using Cedar.WebPortal.Domain.Resources;

    public class News
    {
        #region Constructors and Destructors

        public News()
        {
            this.CreatedAt = DateTime.Now;
            this.PublishDate = DateTime.Now;
        }

        #endregion

        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "News_AppearInHomePage")]
        public virtual bool AppearInHomePage { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Attachment")]
        public virtual Attachment Attachment { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_CreatedAt")]
        public virtual DateTime? CreatedAt { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Code")]
        public virtual long Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Contents")]
        public virtual string Contents { get; set; }

//        public virtual UserProfile Creator { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_ExpirationDate")]
        public virtual DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Language")]
        public virtual Language Language { get; set; }

        public virtual Guid NewsId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_PublishDate")]
        public virtual DateTime PublishDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Published")]
        public virtual bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Title")]
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
            if (obj.GetType() != typeof(News))
            {
                return false;
            }
            return this.Equals((News)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (this.Attachment != null ? this.Attachment.GetHashCode() : 0);
                result = (result * 397) ^ this.CreatedAt.GetHashCode();
                result = (result * 397) ^ this.Code.GetHashCode();
                result = (result * 397) ^ (this.Contents != null ? this.Contents.GetHashCode() : 0);
                result = (result * 397) ^ this.NewsId.GetHashCode();
                result = (result * 397) ^ this.PublishDate.GetHashCode();
                result = (result * 397) ^ this.ExpirationDate.GetHashCode();
                result = (result * 397) ^ this.Published.GetHashCode();
                result = (result * 397) ^ this.Language.GetHashCode();
                result = (result * 397) ^ (this.Title != null ? this.Title.GetHashCode() : 0);
                return result;
            }
        }

        #endregion

        #region Methods

        protected virtual bool Equals(News other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Attachment, this.Attachment) && other.CreatedAt.Equals(this.CreatedAt) &&
                   other.Code == this.Code && Equals(other.Contents, this.Contents) && other.NewsId.Equals(this.NewsId) &&
                   other.ExpirationDate.Equals(this.ExpirationDate) && other.PublishDate.Equals(this.PublishDate) &&
                   other.Published.Equals(this.Published) && Equals(other.Title, this.Title) &&
                   other.Language.Equals(this.Language);
        }

        #endregion
    }
}