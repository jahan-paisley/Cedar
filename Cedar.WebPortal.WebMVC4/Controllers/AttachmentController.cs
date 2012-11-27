using System;
using System.Web.Mvc;

namespace Cedar.WebPortal.WebMVC4.Controllers
{
    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Service;
    using Cedar.WebPortal.Service.Common;

    public class AttachmentController : Controller
    {
         IAttachmentService attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        public ActionResult Index(Guid id)
        {
            var attachment = this.attachmentService.GetById(id);
            return attachment.IsNull() ? null : this.File(attachment.Contents, attachment.ContentType,attachment.FileName);
        }
    }
}
