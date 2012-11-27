namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Cedar.WebPortal.Common;

    public static class HtmlHelperExtensionForEditorForDateTime
    {

        public static MvcHtmlString Editor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

           
            string propname = html.ViewData.Model.Item(expression);
            string incomingValue = null;
            var httpCookie = html.ViewContext.RequestContext.HttpContext.Request.Cookies["lang"];
            if (metadata.Model is DateTime && (httpCookie.IsNull() || httpCookie.Value == Cultures.Persian))
                incomingValue = PersianCalendarUtility.ConvertToPersian(((DateTime)metadata.Model).ToShortDateString());
            if (string.IsNullOrEmpty(incomingValue))
                return html.TextBox(propname, null, new { @class = "datepicker TextField" });

            return html.TextBox(propname, incomingValue, new { @class = "datepicker TextField"});
        }

    }
}