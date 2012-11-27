namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensionForTextBoxFor
    {
            public static MvcHtmlString TextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TValue>> expression, bool isTextField)
            {
                return !isTextField ? htmlHelper.TextBoxFor(expression) : htmlHelper.TextBoxFor(expression, new { @class = "TextField" });
            }
    }
}