using Cedar.WebPortal.Domain.Enums;

namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class Relative
    {
        #region Properties

        public virtual Guid RelativeId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Relative_FirstName")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Relative_LastName")]
        public virtual string LastName { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_BirthDate")]
        public virtual int BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Relative_Relation")]
        public virtual FamilyRelation Relation { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_WorkPosition")]
        public virtual string WorkPosition { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_EducationLevel")]
        public virtual EducationLevel EducationLevel { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_Hometown")]
        public virtual string Hometown { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_HabitationCity")]
        public virtual string HabitationCity { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Relative_Workplace")]
        public virtual string Workplace { get; set; }

        #endregion
    }
}