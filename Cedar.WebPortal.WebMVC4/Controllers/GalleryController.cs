using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using MvcContrib.Pagination;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.Domain.Component;
using Cedar.WebPortal.Service.Common;
using Cedar.WebPortal.WebMVC4.ViewModel;

namespace Cedar.WebPortal.WebMVC4.Controllers
{
    public class GalleryController : Controller
    {
        #region Constants and Fields

        private readonly IAttachmentService _attachmentService;
        private readonly IGalleryService _galleryService;

        #endregion

        #region Constructors and Destructors

        public GalleryController(IGalleryService galleryService, IAttachmentService attachmentService)
        {
            _galleryService = galleryService;
            _attachmentService = attachmentService;
        }

        #endregion

        #region Public Methods

        public PartialViewResult GalleryList()
        {
            return PartialView("GalleryList", new Gallery());
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Confirm()
        {
            IEnumerable<Gallery> gallery = _galleryService.GetUnpublishedGallery();
            return View("ListPagination", gallery);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult FileAttach()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create()
        {
            var gallery = new GalleryViewModel();
            return View(gallery);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create(GalleryViewModel galleryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(galleryViewModel);
            }
            Gallery gallery = null;
            gallery = Mapper.Map(galleryViewModel, gallery);
            gallery.CreatorUser = new User { Username = this.User.Identity.Name };
            _galleryService.Add(gallery);
            galleryViewModel.GalleryId = gallery.GalleryId;
            return View("FileAttach", galleryViewModel);
        }

        [Authorize(Roles = "Administrator")]
        public void Delete(Guid id)
        {
            _galleryService.Delete(o => o.GalleryId == id);
        }

        public ActionResult Details(Guid id)
        {
            GalleryViewModel galleryViewModel = null;
            galleryViewModel = Mapper.Map(_galleryService.GetPublishedGallery(id), galleryViewModel);
            return View("Details", galleryViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator, Publisher")]
        public ActionResult Edit(GalleryViewModel galleryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(galleryViewModel);
            }
            if (TempData["Attachments"].IsNotNull())
                galleryViewModel.Attachments = (IList<Attachment>)TempData["Attachments"];
            Gallery gallery = null;
            gallery = Mapper.Map(galleryViewModel, gallery);
            gallery.CreatorUser = new User { Username = User.Identity.Name };
            _galleryService.Save(gallery);
            return View("FileAttach", galleryViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Publisher")]
        public ActionResult Edit(Guid id)
        {
            Gallery Gallery = _galleryService.GetPublishedGallery(id);
            GalleryViewModel galleryViewModel = null;
            galleryViewModel = Mapper.Map(Gallery, galleryViewModel);
            TempData["Attachments"] = galleryViewModel.Attachments;
            return View("Edit", galleryViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("ListPagination");
        }

        public ActionResult List()
        {
            if (User.IsInRole("Administrator"))
            {
                IEnumerable<Gallery> gallery = _galleryService.GetAll().AsPagination(1, 10);
                return View("List", gallery);
            }
            else
            {
                IEnumerable<Gallery> gallery = _galleryService.GetPublishedGallery().AsPagination(1, 10);
                ;
                return View("List", gallery);
            }
        }

        public ActionResult ListPagination(int? page)
        {
            if (User.IsInRole("Administrator"))
            {
                IEnumerable<Gallery> gallery = _galleryService.GetAll().AsPagination(page ?? 1, 10);
                return View(gallery);
            }
            else
            {
                IEnumerable<Gallery> gallery = _galleryService.GetPublishedGallery().AsPagination(page ?? 1, 10);
                ;
                return View(gallery);
            }
        }

        //[HttpPost]
        //public ActionResult Success()
        //{
        //    Guid id = Guid.Empty;
        //    if (Request.Form["GalleryId"] != null)
        //    {
        //        id = Guid.Parse(Request.Form["GalleryId"]);
        //        Gallery gallery = _galleryService.GetById(id);

        //        //todo:Check for null tempdata
        //        foreach (Guid guid in (List<Guid>)TempData["AttachmentsId"])
        //        {
        //            gallery.Attachments.Add(_attachmentService.GetById(guid));
        //        }
        //        _galleryService.Save(gallery);
        //    }
        //    return RedirectToAction("ListPagination");
        //}

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult AsyncUpload(Guid galleryId, string title, Attachment attachment)
        {
            Attachment _attachment = attachment;
            _attachment.AttachmentId = Guid.NewGuid();
            _attachment.Tag = "PictureGallery";
            _galleryService.SaveIndividualAttachment(galleryId,_attachment);

            //var attachmentsId = new List<Guid>();
            //attachment.AttachmentId = Guid.NewGuid();
            //attachment.Tag = "PictureGallery";

            //_attachmentService.Add(attachment);
            //if (TempData["AttachmentsId"] != null)
            //{
            //    attachmentsId = (List<Guid>)TempData["AttachmentsId"];
            //}
            //attachmentsId.Add(attachment.AttachmentId);
            //TempData["AttachmentsId"] = attachmentsId;
            return
                Json(
                    new
                        {
                            data = attachment.AttachmentId.ToString(),
                            success = true,
                            message = "success"
                        },
                    "text/html",
                    Encoding.UTF8);
        }

        public bool DeleteUpload(Guid galleryId,Guid attachmentId)
        {
            _galleryService.DeleteById(galleryId,attachmentId);
            return true;
        }

        #endregion
    }
}