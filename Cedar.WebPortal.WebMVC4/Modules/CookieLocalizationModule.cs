using System;
using System.Web;

namespace Cedar.WebPortal.WebMVC4.Modules
{
    using System.Threading;

    /// <summary>
    /// You will need to configure this module in the web.config file of your
    /// web and register it with IIS before being able to use it. For more information
    /// see the following link: http://go.microsoft.com/?linkid=8101007
    /// </summary>
    public class CookieLocalizationModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        #endregion

        private static void context_BeginRequest(object sender, EventArgs e)
        {
            // eat the cookie (if any) and set the culture
            if (HttpContext.Current.Request.Cookies["lang"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
                if (cookie != null)
                {
                    var lang = cookie.Value;
                    var culture = new System.Globalization.CultureInfo(lang);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
            else
            {
                var culture = new System.Globalization.CultureInfo(0x429);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
    }
}