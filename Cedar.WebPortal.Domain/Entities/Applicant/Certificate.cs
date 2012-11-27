using Cedar.WebPortal.Common;

namespace Cedar.WebPortal.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Cedar.WebPortal.Domain.Resources;

    public class Certificate
    {
        #region Constructors and Destructors

        public Certificate()
        {
        }

        #endregion

        #region Properties

        public virtual Guid CertificateId { get; set; }

        public virtual Applicant Applicant { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_Title")]
        public virtual string Title { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_Institute")]
        public virtual string Institute { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_Date")]
        public virtual DateTime? Date { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_Location")]
        public virtual string Location { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_Duration")]
        public virtual float Duration { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Certificate_HasDocument")]
        public virtual bool? HasDocument { get; set; }

        #endregion
    }
}