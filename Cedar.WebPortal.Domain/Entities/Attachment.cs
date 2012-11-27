namespace Cedar.WebPortal.Domain
{
    using System;

    public class Attachment
    {
        #region Properties

        public virtual Guid AttachmentId { get; set; }

        public virtual int? ContentLength { get; set; }

        public virtual string ContentType { get; set; }

        public virtual byte[] Contents { get; set; }

        public virtual DateTime? DateAdded { get; set; }

        public virtual string FileName { get; set; }

        public virtual string Tag { get; set; }

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
            if (obj.GetType() != typeof(Attachment))
            {
                return false;
            }
            return this.Equals((Attachment)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.AttachmentId.GetHashCode();
                result = (result * 397) ^ (this.ContentLength.HasValue ? this.ContentLength.Value : 0);
                result = (result * 397) ^ (this.ContentType != null ? this.ContentType.GetHashCode() : 0);
                result = (result * 397) ^ (this.Contents != null ? this.Contents.GetHashCode() : 0);
                result = (result * 397) ^ (this.DateAdded.HasValue ? this.DateAdded.Value.GetHashCode() : 0);
                result = (result * 397) ^ (this.FileName != null ? this.FileName.GetHashCode() : 0);
                result = (result * 397) ^ (this.Tag != null ? this.Tag.GetHashCode() : 0);
                result = (result * 397) ^ (this.Title != null ? this.Title.GetHashCode() : 0);
                return result;
            }
        }

        #endregion

        #region Methods

        protected virtual bool Equals(Attachment other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.AttachmentId.Equals(this.AttachmentId) && other.ContentLength.Equals(this.ContentLength) &&
                   Equals(other.ContentType, this.ContentType) && Equals(other.Contents, this.Contents) &&
                   other.DateAdded.Equals(this.DateAdded) && Equals(other.FileName, this.FileName)
                   && Equals(other.Tag, this.Tag) && Equals(other.Title, this.Title)
                   ;
        }

        #endregion
    }
}