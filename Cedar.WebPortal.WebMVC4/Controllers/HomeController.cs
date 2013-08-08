namespace MvcApplication1.Controllers
{
    using System;
    using System.Web.Mvc;

    using Cedar.WebPortal.Service.Common;

    using System.Linq;

    public class HomeController : Controller
    {
        #region Constants and Fields

        private readonly INewsService newsService;

        #endregion

        #region Constructors and Destructors

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        #endregion

        #region Public Methods

        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult Index()
        {
            this.ViewBag.Message = String.Join(",", newsService.GetAll().Select(o=> o.Title));
            return this.View();
        }

        #endregion
    }
}