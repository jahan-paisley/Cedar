namespace Cedar.WebPortal.Domain.Enums
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class SocialSecurityInfo
    {
        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "SocialSecurityInfo_Type")]
        public virtual string Type { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "SocialSecurityInfo_Has")]
        public virtual bool? Has { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "SocialSecurityInfo_Duration")]
        public virtual float Duration { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "SocialSecurityInfo_OthersDuration")]
        public virtual float OthersDuration { get; set; }

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
            if (obj.GetType() != typeof(SocialSecurityInfo))
            {
                return false;
            }
            return Equals((SocialSecurityInfo)obj);
        }

        #endregion

        protected virtual bool Equals(SocialSecurityInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Type, this.Type) && other.Has.Equals(this.Has) && other.OthersDuration.Equals(this.OthersDuration);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (this.Type != null ? this.Type.GetHashCode() : 0);
                result = (result * 397) ^ (this.Has.HasValue ? this.Has.Value.GetHashCode() : 0);
                result = (result * 397) ^ this.OthersDuration.GetHashCode();
                return result;
            }
        }
    }
}