using System.Collections.Generic;

namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class Location
    {
        public Location()
        {
        }
        #region Properties

        public virtual Guid LocationId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Location_Province")]
        public virtual string Province { get; set; }

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
            if (obj.GetType() != typeof(Location))
            {
                return false;
            }
            return this.Equals((Location)obj);
        }

        public virtual bool Equals(Location other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.LocationId.Equals(this.LocationId);
        }

        public override int GetHashCode()
        {
            return this.LocationId.GetHashCode();
        }

        public override string ToString()
        {
            return this.LocationId.ToString();
        }

        #endregion
    }
}