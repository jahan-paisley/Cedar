namespace Cedar.WebPortal.WebMVC4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Cedar.WebPortal.Domain.Entities;
    using Cedar.WebPortal.Domain.Enums;
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

        [HttpGet]
        public ActionResult Confirm()
        {
            IEnumerable<News> news = this.newsService.GetUnpublishedNews().Take(10);
            return View("List", news);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var news = new NewsViewModel();
            return this.View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(newsViewModel);
            }
            News news = null;

            news = Mapper.Map(newsViewModel, news);
            this.newsService.Add(news);
            return this.RedirectToAction("List");
        }

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
        public ActionResult Edit(NewsViewModel newsViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(newsViewModel);
            }
            News news = null;
            news = Mapper.Map(newsViewModel, news);
            this.newsService.Save(news);
            return this.RedirectToAction("List");
        }

        [HttpGet]
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
            IEnumerable<News> news = this.newsService.GetAll().Take(10);
            return View("List", news);
        }

        public ActionResult ListPagination(int? page)
        {
            IEnumerable<News> news = this.newsService.GetAll().Skip(!page.HasValue ? 0 : page.Value * 10).Take(10);
            return View(news);
        }

        public PartialViewResult NewsList()
        {
            return this.PartialView("NewsList", new News());
        }

        #endregion
    }
}