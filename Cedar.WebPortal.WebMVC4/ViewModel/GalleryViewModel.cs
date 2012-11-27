using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Domain.Resources;

namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    public class GalleryViewModel:Gallery
    {
        [Display(ResourceType = typeof (EntityResource), Name = "Gallery_PublishDate")]
        public string PublishDate { get; set; }

    }

   
}