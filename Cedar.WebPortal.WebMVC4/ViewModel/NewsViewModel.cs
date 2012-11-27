using Cedar.WebPortal.Common;

namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    using Domain;
    using Domain.Resources;

    public class NewsViewModel : News
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(PersianCalendarUtility.PersianDateRegex, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "date")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_PublishDate")]
        public new string PublishDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(PersianCalendarUtility.PersianDateRegex, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "date")]
        [Display(ResourceType = typeof(EntityResource), Name = "News_ExpirationDate")]
        public new string ExpirationDate { get; set; }

        #endregion
    }
}