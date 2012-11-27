namespace MvcApplication1.Controllers
{
    using System;
    using System.Web.Mvc;

    using Cedar.WebPortal.Service.Common;

    public class HomeController : Controller
    {
        #region Constants and Fields

        private INewsService newsService;

        #endregion

        #region Constructors and Destructors

        public HomeController(INewsService _newsService)
        {
            if (_newsService == null)
            {
                throw new ArgumentNullException("_newsService");
            }
            this.newsService = _newsService;
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
            this.ViewBag.Message = newsService.GetAll();

            return this.View();
        }

        #endregion
    }
}