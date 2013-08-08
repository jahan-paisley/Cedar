namespace Cedar.WebPortal.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class Publication
    {
        #region Properties

        public virtual Applicant Applicant { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Publication_Date")]
        public virtual DateTime? Date { get; set; }

        public virtual Guid PublicationId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Publication_Publisher")]
        public virtual string Publisher { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Publication_Title")]
        public virtual string Title { get; set; }

        #endregion
    }
}