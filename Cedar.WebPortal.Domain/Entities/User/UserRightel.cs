using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain.Resources;

namespace Cedar.WebPortal.Domain
{

    public class UserRightel
    {
        public UserRightel()
        {
            //this.Tickets=new Collection<Ticket>();
        }

        public virtual Guid UserRightelId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        public virtual Guid UserId { get; set; }

        //public virtual IList<Ticket> Tickets { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_FirstName")]
        public virtual string FirstName { get; set; }


        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [StringLength(25)]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_LastName")]
        public virtual string LastName { get; set; }


        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.CellNo, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "mobile")]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_MSISDN")]
        public virtual string MSISDN { get; set; }


        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.CellNo, ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "mobile")]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_MobileNo")]
        public virtual string MobileNo { get; set; }


        [IsNationalNo(ErrorMessageResourceType = typeof(Common.Resources.ValidationResource), ErrorMessageResourceName = "isnationalno")]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_NationalNo")]
        public virtual long NationalNo { get; set; }


        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_Address")]
        public virtual string Address { get; set; }


        [Required(ErrorMessageResourceType = typeof(ValidationResource), ErrorMessageResourceName = "required")]
        [RegularExpression(CellPhone.Digits, ErrorMessageResourceType = typeof(ValidationResource),
           ErrorMessageResourceName = "digits")]
        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_TelNo")]
        public virtual string TelNo { get; set; }


        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_City")]
        public virtual string Province { get; set; }


        [Display(ResourceType = typeof(EntityResource), Name = "Ticket_City")]
        public virtual string City { get; set; }

        public virtual DateTime CaptureData { get; set; }
    }
}