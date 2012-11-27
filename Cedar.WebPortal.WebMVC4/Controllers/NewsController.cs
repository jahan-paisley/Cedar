using System.Web.UI;
using MvcContrib.Pagination;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain.Component;

namespace Cedar.WebPortal.WebMVC4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.WebMVC4.ViewModel;

    public class NewsController : Controller
    {
        #region Constants and Fields

        private readonly INewsService newsService;

        #endregion

        #region Constructors and Destructors

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        #endregion

        #region Public Methods

        public PartialViewResult NewsList()
        {
            return PartialView("NewsList", new News());
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Confirm()
        {
            IEnumerable<News> news = this.newsService.GetUnpublishedNews().AsPagination(1, 10);
            return View("ListPagination",news);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create()
        {
            var news = new NewsViewModel();
            return this.View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,Publisher")]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(newsViewModel);
            }
            News news = null;

            news = Mapper.Map(newsViewModel, news);
            news.Language = Language.Fa;
            //            news.CreatorUser = new User { Username = this.User.Identity.Name };
            this.newsService.Add(news);
            return this.RedirectToAction("ListPagination");
        }

        [Authorize(Roles = "Administrator")]
        public void Delete(Guid id)
        {
            this.newsService.Delete(o => o.NewsId == id);
        }

        public ActionResult Details(Guid id)
        {
            NewsViewModel newsViewModel = null;
            newsViewModel = Mapper.Map(this.newsService.GetPublishedNews(id), newsViewModel);
            return View("Details", newsViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator, Publisher")]
        public ActionResult Edit(NewsViewModel newsViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(newsViewModel);
            }

            News news = null;
            news = Mapper.Map(newsViewModel, news);
            news.Language = Language.Fa;
            news.CreatorUser = new User { Username = this.User.Identity.Name };
            this.newsService.Save(news);
            return this.RedirectToAction("ListPagination");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Publisher")]
        public ActionResult Edit(Guid id)
        {
            News news = this.newsService.GetPublishedNews(id);
            NewsViewModel newsViewModel = null;
            newsViewModel = Mapper.Map(news, newsViewModel);
            return View("Edit", newsViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.List();
        }

        public ActionResult List()
        {
            if (this.User.IsInRole("Administrator"))
            {
                IEnumerable<News> news = this.newsService.GetAll().AsPagination(1, 10);
                return View("List", news);
            }
            else
            {
                IEnumerable<News> news = this.newsService.GetPublishedNews().AsPagination(1, 10);
                return View("List", news);
            }
        }

        public ActionResult ListPagination(int? page)
        {
            if (this.User.IsInRole("Administrator"))
            {
                IEnumerable<News> news = this.newsService.GetAll().AsPagination(page ?? 1, 10);
                return View(news);
            }
            else
            {
                IEnumerable<News> news = this.newsService.GetPublishedNews().AsPagination(page ?? 1, 10);
                ;
                return View(news);
            }

        }

        #endregion
    }
}