namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Diagnostics;
    using System.Web;
    using System.Web.Mvc;

    using Cedar.WebPortal.Common;

    public static class HtmlHelperExtensionForLocalization
    {
        public static string LeftIfPersian(this HtmlHelper htmlHelper)
        {
            HttpCookie httpCookie = htmlHelper.ViewContext.HttpContext.Request.Cookies["lang"];
            return (httpCookie==null || httpCookie.Value == Cultures.Persian) ? "left" : "right";
        }

        public static string RightIfPersian(this HtmlHelper htmlHelper)
        {
            HttpCookie httpCookie = htmlHelper.ViewContext.HttpContext.Request.Cookies["lang"];
            return httpCookie != null && httpCookie.Value == Cultures.Persian ? "right" : "left";
        }

        public static string GetViewName(this Controller controller, string viewname)
        {
            Debug.Assert(controller != null, "controller != null");
            var httpCookie = controller.ControllerContext.HttpContext.Request.Cookies["lang"];
            if (httpCookie != null && httpCookie.Value == Cultures.Persian)
            {
                return viewname;
            }
            if(httpCookie != null)
                return viewname + "." + httpCookie.Value;
            return viewname;
        }
    }
}