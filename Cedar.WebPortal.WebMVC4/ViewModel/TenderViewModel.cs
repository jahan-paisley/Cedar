using System;
using System.Collections.Generic;
using Cedar.WebPortal.Domain.Component;
using Cedar.WebPortal.Domain.Resources;
using Cedar.WebPortal.Web.Helpers;

namespace Cedar.WebPortal.Web.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    using Domain;

    public class TenderViewModel : Tender
    {
        public virtual Guid TenderId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_TenderType")]
        public virtual TenderType TenderType { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_Title")]
        public virtual string Title { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_TenderNo")]
        public virtual string TenderNo { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_TenderStep")]
        public virtual TenderStep TenderStep { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_TenderText")]
        public virtual string TenderText { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_TenderApplications")]
        public virtual IList<TenderApplication> TenderApplications { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_ExpirationDate")]
        public virtual DateTime ExpirationDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Tender_Active")]
        public virtual bool Active { get; set; }

        [BooleanRequired(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "IAgree")]
        [Display(ResourceType = typeof(GlossaryResource), Name = "IAgree")]
        public bool IAgree { get; set; }
    }
}