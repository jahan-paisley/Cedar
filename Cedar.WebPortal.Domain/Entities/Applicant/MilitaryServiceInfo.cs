namespace Cedar.WebPortal.Domain.Component
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Resources;

    public class MilitaryServiceInfo
    {
        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_Status")]
        public MilitaryServiceStatus Status{get ;set ;}

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_Location")]
        public virtual string Location { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_Start")]
        public virtual DateTime? Start { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_Finish")]
        public virtual DateTime? Finish { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_CardNo")]
        public virtual string CardNo { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_Exempt")]
        public virtual bool? Exempt { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "MilitaryServiceInfo_ExemptReason")]
        public virtual string ExemptReason { get; set; }

        #endregion

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
            if (obj.GetType() != typeof(MilitaryServiceInfo))
            {
                return false;
            }
            return Equals((MilitaryServiceInfo)obj);
        }

        protected virtual bool Equals(MilitaryServiceInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Status, this.Status) && Equals(other.Location, this.Location) && other.Start.Equals(this.Start) && other.Finish.Equals(this.Finish) && Equals(other.CardNo, this.CardNo) && other.Exempt.Equals(this.Exempt) && other.ExemptReason.Equals(this.ExemptReason);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (this.Status.GetHashCode());
                result = (result * 397) ^ (this.Location != null ? this.Location.GetHashCode() : 0);
                result = (result * 397) ^ (this.Start.HasValue ? this.Start.Value.GetHashCode() : 0);
                result = (result * 397) ^ (this.Finish.HasValue ? this.Finish.Value.GetHashCode() : 0);
                result = (result * 397) ^ (this.CardNo != null ? this.CardNo.GetHashCode() : 0);
                result = (result * 397) ^ (this.Exempt.HasValue ? this.Exempt.Value.GetHashCode() : 0);
                result = (result * 397) ^ (this.ExemptReason != null ? this.ExemptReason.GetHashCode() : 0);
                return result;
            }
        }
    }
}