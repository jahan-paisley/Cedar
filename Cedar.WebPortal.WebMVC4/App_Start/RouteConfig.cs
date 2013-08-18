namespace Cedar.WebPortal.WebMVC4
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        #region Public Methods

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("FaLocalization", "fa/{controller}/{action}/{id}", new { controller = "News", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("EnLocalization", "en/{controller}/{action}/{id}", new { controller = "News", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "News", action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}