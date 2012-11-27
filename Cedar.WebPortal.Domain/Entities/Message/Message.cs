namespace Cedar.WebPortal.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Resources;

    public class Message
    {
        public Message()
        {
            CaptureDate = DateTime.Now;
        }
        #region Properties

        [Display(ResourceType = typeof(EntityResource), Name = "Message_CaptureDate")]
        public virtual DateTime? CaptureDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_Contents")]
        [Required]
        [StringLength(4000)]
        public virtual string Contents { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_AnswerContents")]
        [StringLength(4000)]
        public virtual string AnswerContents { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_AnswerDate")]
        public virtual DateTime? AnswerDate { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_EMail")]
        public virtual string EMail { get; set; }

        public virtual Guid MessageId { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_LastName")]
        public virtual string LastName { get; set; }

        [Display(ResourceType = typeof(EntityResource), Name = "Message_Name")]
        public virtual string Name { get; set; }

        public virtual bool Published { get; set; }

        #endregion
    }
}