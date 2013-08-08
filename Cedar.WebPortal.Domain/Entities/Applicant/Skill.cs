using Cedar.WebPortal.Domain.Enums;

namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class Skill
    {
        #region Constructors and Destructors

        public Skill()
        {
        }

        #endregion

        #region Properties

        public virtual Guid SkillId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Skill_Title")]
        public virtual string Title { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Skill_Level")]
        public virtual SkillLevel Level { get; set; }
        #endregion
    }
}