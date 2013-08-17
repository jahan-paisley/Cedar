namespace Cedar.WebPortal.Domain.Interfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Common;
    using Enums;
    using Cedar.WebPortal.Domain.Resources;

    public abstract class Person
    {
        #region Properties

        public virtual Guid PersonId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_FirstName")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_LastName")]
        public virtual string LastName { get; set; }

        [NationalNo(ErrorMessageResourceType = typeof(Common.Resources.ValidationResource),
            ErrorMessageResourceName = "nationalno")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_NationalNo")]
        public virtual long NationalNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_BirthDate")]
        public virtual DateTime? BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_IdentityNo")]
        public virtual string IdentityNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Gender")]
        public virtual Gender Gender { get; set; }

        #endregion
    }
}