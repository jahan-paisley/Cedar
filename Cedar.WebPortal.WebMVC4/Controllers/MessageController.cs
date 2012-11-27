namespace Cedar.WebPortal.WebMVC4.Controllers
{
    using System;
    using System.Web.Mvc;

    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Domain.Resources;
    using Cedar.WebPortal.Service.Common;

    public class MessageController : Controller
    {
        #region Constants and Fields

        private readonly IMessageService messageService;

        #endregion

        #region Constructors and Destructors

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ViewResult Create()
        {
            return this.View(new Message());
        }

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (this.ModelState.IsValid)
            {
                messageService.CreateMessage(message);
                TempData["message"] = GlossaryResource.Message_Success;
                return this.View("Create");
            }
            else
            {
                return View(message);
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult List()
        {

            var messages = this.messageService.GetPublishedMessages();
            return this.View(messages);
        }

        #endregion

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ViewResult Edit(Guid id)
        {
            return View(messageService.GetMessage(id));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                var message1 = messageService.GetMessage(message.MessageId);
                message1 = message;
                messageService.SaveMessage();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}