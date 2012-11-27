using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain.Component;

namespace Cedar.WebPortal.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class WorkExperienceInfo
    {
        #region Properties

        public virtual Guid WorkExperienceInfoId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Company")]
        public virtual string Company { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Industry")]
        public virtual string Industry { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_ContractType")]
        public virtual ContractType ContractType { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Position")]
        public virtual string Position { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Start")]
        public virtual DateTime? Start { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Finish")]
        public virtual DateTime? Finish { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Suboridnates")]
        public virtual int Suboridnates { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_Salary")]
        public virtual float Salary { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_QuitReason")]
        public virtual string QuitReason { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_TelNo")]
        public virtual string TelNo { get; set; }

        [StringLength(2000)]
        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "WorkExperienceInfo_JobDescription")]
        public virtual string JobDescription { get; set; }

        #endregion
    }
}