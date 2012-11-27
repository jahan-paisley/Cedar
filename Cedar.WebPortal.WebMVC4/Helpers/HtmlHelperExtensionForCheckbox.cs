namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlHelperExtensionForCheckbox
    {
        public static MvcHtmlString CheckBoxForNonNullable<TItem>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, bool>> expression)
        {
            var chk = htmlHelper.CheckBoxFor(expression, false).ToHtmlString();
            return MvcHtmlString.Create(chk);
        }
    }
}