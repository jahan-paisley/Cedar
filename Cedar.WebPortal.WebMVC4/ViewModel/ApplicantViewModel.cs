using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Domain.Resources;
using Cedar.WebPortal.WebMVC4.Helpers;

namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    public sealed class ApplicantViewModel : Applicant
    {
        #region Properties

        [BooleanRequired(ErrorMessageResourceType = typeof (ValidationResource),
            ErrorMessageResourceName = "checkboxrequired")]
        [Display(ResourceType = typeof (EntityResource), Name = "Applicant_IAgree")]
        public bool IAgree { get; set; }

        #endregion
    }
}