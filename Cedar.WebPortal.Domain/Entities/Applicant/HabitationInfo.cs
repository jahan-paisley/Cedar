using Cedar.WebPortal.Domain.Component;

namespace Cedar.WebPortal.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class HabitationInfo
    {
        #region Constructors and Destructors

        public HabitationInfo()
        {
        }

        #endregion

        #region Properties

        public virtual Guid HabitationInfoId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "HabitationInfo_Start")]
        public virtual DateTime? Start { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "HabitationInfo_Finish")]
        public virtual DateTime? Finish { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "HabitationInfo_Address")]
        public virtual string Address { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "HabitationInfo_Zip")]
        public virtual string Zip { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "HabitationInfo_HabitaionType")]
        public virtual HabitaionType HabitaionType { get; set; }

        #endregion
    }
}