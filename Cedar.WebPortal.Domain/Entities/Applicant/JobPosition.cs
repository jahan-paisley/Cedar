using System;
using System.ComponentModel.DataAnnotations;
using Cedar.WebPortal.Domain.Resources;

namespace Cedar.WebPortal.Domain
{
    public class JobPosition
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "jobposition")]
        public virtual Guid JobPositionId { get; set; }

        public virtual string JobCode { get; set; }

        public virtual string JobTitle { get; set; }

        public virtual string JobEducation { get; set; }

        public virtual string JobSkills { get; set; }

        public virtual Department Department { get; set; }

        #endregion
    }
}