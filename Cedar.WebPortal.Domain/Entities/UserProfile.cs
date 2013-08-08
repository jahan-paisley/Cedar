namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Resources;

    public class UserProfile
    {
        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_Address")]
        public virtual string Address { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_City")]
        public virtual string City { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_CreatedAt")]
        public virtual DateTime? CreatedAt { get; set; }

        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_FirstName")]
        public virtual string FirstName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_Username")]
        public virtual string Username { get; set; }

        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_LastName")]
        public virtual string LastName { get; set; }

        [RegularExpression(CellPhone.CellNo, ErrorMessageResourceType = typeof(ValidationResource),
            ErrorMessageResourceName = "mobile")]
        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_MobileNo")]
        public virtual string MobileNo { get; set; }

        [IsNationalNo(ErrorMessageResourceType = typeof(Common.Resources.ValidationResource),
            ErrorMessageResourceName = "isnationalno")]
        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_NationalNo")]
        public virtual long NationalNo { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_City")]
        public virtual string Province { get; set; }

        [RegularExpression(CellPhone.Digits, ErrorMessageResourceType = typeof(ValidationResource),
            ErrorMessageResourceName = "digits")]
        [Display(ResourceType = typeof(EntityResource), Name = "UserProfile_TelNo")]
        public virtual string TelNo { get; set; }

        #endregion
    }
}