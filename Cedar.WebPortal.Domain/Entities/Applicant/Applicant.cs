using Cedar.WebPortal.Domain.Enums;

namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Resources;

    public class Applicant
    {
        #region Constructors and Destructors

        public Applicant()
        {
            this.Publications = new Collection<Publication>();
            this.Certificates = new Collection<Certificate>();
            this.SocialSecurityInfo = new SocialSecurityInfo();
            this.EducationInfos = new Collection<EducationInfo>();
            this.WorkExperienceInfos = new Collection<WorkExperienceInfo>();
            this.HabitationInfos = new Collection<HabitationInfo>();
            this.Relatives = new Collection<Relative>();
            this.Skills = new Collection<Skill>();
            this.LanguageSkills = new Collection<LanguageSkill>();
            this.ApplicationDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public virtual Guid ApplicantId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_FirstName")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_LastName")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_FirstNameInEnglish")]
        public virtual string FirstNameInEnglish { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_LastNameInEnglish")]
        public virtual string LastNameInEnglish { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_BirthDate")]
        public virtual DateTime? BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_IdentityNo")]
        public virtual string IdentityNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Gender")]
        public virtual Gender Gender { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Hometown")]
        public virtual string Hometown { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_MaritalStatus")]
        public virtual MaritalStatus MaritalStatus { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ChildCount")]
        public virtual int ChildCount { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Height")]
        public virtual float Height { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Weight")]
        public virtual float Weight { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.CellNo, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "mobile")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_MobileNo")]
        public virtual string MobileNo { get; set; }

        [RegularExpression(CellPhone.TelNoWithTelCode, ErrorMessageResourceType = typeof(ValidationResource),
          ErrorMessageResourceName = "telandcode")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_HomeTelNo")]
        public virtual string HomeTelNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.TelNoWithTelCode, ErrorMessageResourceType = typeof(ValidationResource),
          ErrorMessageResourceName = "telandcode")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_EmeregencyTelNo")]
        public virtual string EmeregencyTelNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(Common.EmailAddress.Email, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "email")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_EMail")]
        public virtual string EMail { get; set; }

        [IsNationalNo(ErrorMessageResourceType = typeof(Common.Resources.ValidationResource), ErrorMessageResourceName = "isnationalno")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_NationalNo")]
        public virtual long NationalNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Address")]
        public virtual string Address { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ApplicationDate")]
        public virtual DateTime? ApplicationDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_AcquaintanceWay")]
        public virtual AcquaintanceWay AcquaintanceWay { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Activities")]
        public virtual string Activities { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ContractType")]
        public virtual ContractType ContractType { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ExpectedSalary")]
        public virtual float ExpectedSalary { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Conviction")]
        public virtual bool? Conviction { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_CriminalRecord")]
        public virtual string CriminalRecord { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Disability")]
        public virtual string Disability { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ErrandTendency")]
        public virtual bool? ErrandTendency { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_ErrandDays")]
        public virtual int ErrandDays { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_HolidayNotWorkingReason")]
        public virtual string HolidayNotWorkingReason { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_HolidayWork")]
        public virtual bool? HolidayWork { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_IdealWorkplace")]
        public virtual string IdealWorkplace { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "jobposition")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_JobTitle")]
        public virtual JobPosition JobPosition { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_OtherSkills")]
        public virtual string OtherSkills { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_OvertimeWork")]
        public virtual bool? OvertimeWork { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_OvertimeWorkHours")]
        public virtual int OvertimeWorkHours { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_PreviousInterviews")]
        public virtual bool PreviousInterviews { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_RelativeInCompany")]
        public virtual string RelativeInCompany { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.Digits, ErrorMessageResourceType = typeof(ValidationResource),
           ErrorMessageResourceName = "digits")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_TelNo")]
        public virtual string TelNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_WhenAvailable")]
        public virtual int WhenAvailable { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Picture")]
        public virtual Attachment Picture { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_CV")]
        public virtual Attachment CV { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "englishcv")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_EnglishCV")]
        public virtual Attachment EnglishCV { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_MilitaryServiceStatus")]
        public virtual MilitaryServiceStatus MilitaryServiceStatus { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_SocialSecurityInfo")]
        public virtual SocialSecurityInfo SocialSecurityInfo { get; set; }

        [CollectionMinLengh(1, ErrorMessageResourceType = typeof(Common.Resources.ValidationResource), ErrorMessageResourceName = "minlist")]
        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_EducationInfos")]
        public virtual IList<EducationInfo> EducationInfos { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Certificates")]
        public virtual IList<Certificate> Certificates { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_HabitationInfos")]
        public virtual IList<HabitationInfo> HabitationInfos { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_LanguageSkills")]
        public virtual IList<LanguageSkill> LanguageSkills { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Publications")]
        public virtual IList<Publication> Publications { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Relatives")]
        public virtual IList<Relative> Relatives { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_Skills")]
        public virtual IList<Skill> Skills { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_WorkExperienceInfos")]
        public virtual IList<WorkExperienceInfo> WorkExperienceInfos { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_FollowupCode")]
        public virtual string FollowupCode { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Applicant_CronicDisease")]
        public virtual string CronicDisease { get; set; }

        #endregion

    }
}
