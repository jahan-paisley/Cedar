namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Entities;
    using Cedar.WebPortal.Domain.Enums;
    using Cedar.WebPortal.Domain.Resources;

    public class NewsViewModel
    {
        #region Constructors and Destructors

        public NewsViewModel()
        {
            this.CreatedAt = DateTime.Now;
        }

        #endregion

        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "News_AppearInHomePage")]
        public bool AppearInHomePage { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Attachment")]
        public Attachment Attachment { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Code")]
        public long Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Contents")]
        public string Contents { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(PersianCalendarUtility.PersianDateRegex,
            ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "date")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_ExpirationDate")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Language")]
        public Language Language { get; set; }

        public Guid NewsId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(PersianCalendarUtility.PersianDateRegex,
            ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "date")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_PublishDate")]
        public string PublishDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "News_Published")]
        public bool Published { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_Title")]
        public string Title { get; set; }

        #endregion
    }
}