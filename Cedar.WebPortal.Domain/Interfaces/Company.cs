namespace Cedar.WebPortal.Domain.Interfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Component;
    using Cedar.WebPortal.Domain.Resources;

    public abstract class Company
    {
        #region Properties

        public virtual Guid CompanyId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_Name")]
        [StringLength(25)]
        public virtual string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_BoardOfDirectors")]
        [StringLength(300)]
        public virtual string BoardOfDirectors { get; set; }


        [Display(ResourceType = typeof(EntityResource), Name = "Address_City")]
        public virtual string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_CompanyActivity")]
        [StringLength(50)]
        public virtual string CompanyActivity { get; set; }

        [RegularExpression(CellPhone.CellNo, ErrorMessageResourceType = typeof(ValidationResource),
            ErrorMessageResourceName = "mobile")]
        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContactPointCellNo")]
        [StringLength(11)]
        public virtual string ContactPointCellNo { get; set; }

        [RegularExpression(EmailAddress.Email, ErrorMessageResourceType = typeof(ValidationResource),
            ErrorMessageResourceName = "email")]
        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContactPointMail")]
        [StringLength(35)]
        public virtual string ContactPointMail { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContactPointNameAndFamily")]
        [StringLength(50)]
        public virtual string ContactPointNameAndFamily { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContactPointPost")]
        [StringLength(50)]
        public virtual string ContactPointPost { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContactPointTelNo")]
        [StringLength(12)]
        public virtual string ContactPointTelNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ContractStaffNo")]
        public virtual Int32 ContractStaffNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_EconomicCode")]
        [StringLength(25)]
        public virtual string EconomicCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_EstablishYear")]
        public virtual Int32 EstablishYear { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Company_FollowupCode")]
        public virtual string FollowupCode { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Distributor_Form")]
        public virtual CompanyForm Form { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_FormalStaffNo")]
        public virtual Int32 FormalStaffNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_IndividualShareHolders")]
        [StringLength(300)]
        public virtual string IndividualShareHolders { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_LegalShareHolders")]
        [StringLength(300)]
        public virtual string LegalShareHoldes { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Company_ManagingDirector")]
        [StringLength(25)]
        public virtual string ManagingDirector { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Company_ProductTools")]
        public virtual Attachment ProductTools { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Location_Province")]
        public virtual string Province { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Company_TechnicalDetails")]
        public virtual Attachment TechnicalDetails { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Company_ValidApprovals")]
        public virtual Attachment ValidApprovals { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Company_YourProposalDocument")]
        public virtual Attachment YourProposalDocument { get; set; }

        #endregion
    }
}