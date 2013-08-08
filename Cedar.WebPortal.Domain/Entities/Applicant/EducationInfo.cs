namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Enums;
    using Cedar.WebPortal.Domain.Resources;

    public class EducationInfo
    {
        #region Properties

        public virtual Guid EducationInfoId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Level")]
        public virtual EducationLevel Level { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_TrainingUnitType")]
        public virtual TrainingUnitType TrainingUnitType { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Major")]
        public virtual string Major { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_College")]
        public virtual string College { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Country")]
        public virtual string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Province")]
        public virtual string Province { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Start")]
        public virtual int Start { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_Finish")]
        public virtual int Finish { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "EducationInfo_GPA")]
        public virtual float GPA { get; set; }

        #endregion
    }
}