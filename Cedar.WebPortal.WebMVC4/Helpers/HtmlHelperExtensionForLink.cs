namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;


    using Cedar.WebPortal.WebMVC4.Resources;

    using Microsoft.Web.Mvc;

    public static class HtmlHelperExtensionForLink
    {
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action) where TController : Controller
        {
            var actionName = ((MethodCallExpression)action.Body).Method.Name;
            var controllerName = action.Parameters[0].Type.Name.Replace("Controller", "");
            var mvcHtmlString = helper.ActionLink(action, HtmlHelperExtensionForResources.ResourceFor(typeof(CommandResource), controllerName + "_" + actionName));
            return mvcHtmlString;
        }
    }
}