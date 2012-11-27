using Cedar.WebPortal.Domain.Component;

namespace Cedar.WebPortal.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class LanguageSkill
    {
        #region Constructors and Destructors

        public LanguageSkill()
        {
        }

        #endregion

        #region Properties

        public virtual Applicant Applicant { get; set; }

        public virtual Guid LanguageSkillId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "LanguageSkill_Language")]
        public virtual string Language { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "LanguageSkill_Reading")]
        public virtual SkillLevel Reading { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "LanguageSkill_Writing")]
        public virtual SkillLevel Writing { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "LanguageSkill_Speaking")]
        public virtual SkillLevel Speaking { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "LanguageSkill_Comprehension")]
        public virtual SkillLevel Comprehension { get; set; }

        #endregion
    }
}