namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain.Resources;
    using Cedar.WebPortal.WebMVC4.Resources;

    public static class HtmlHelperExtensionForResources
    {
        public static string ResourceFor<TItem, TMember>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, TMember>> expression) where TItem : class
        {
            string str = typeof(TItem).Name + "_" + htmlHelper.ViewData.Model.Item(expression);

            return EntityResource.ResourceManager.GetString(str);
        }

        public static string ResourceFor(this HtmlHelper htmlHelper, string key)
        {
            return GlossaryResource.ResourceManager.GetString(key);
        }

        public static string ResourceFor(Type T, string key)
        {
            PropertyInfo propertyInfo = T.GetProperty("ResourceManager");
            MethodInfo methodInfo = propertyInfo.PropertyType.GetMethod("GetString", new[] { typeof(string) });
            object result = methodInfo.Invoke(propertyInfo.GetValue(null, null), new[] { key });
            return result as string;
        }
        
        public static string ResourceFor(this HtmlHelper helper, Type T, string key)
        {
            return ResourceFor(T, key);
        }

        public static string ResourceFor<TController>(this HtmlHelper helper, Expression<Action<TController>> action) where TController : Controller
        {
            var actionName = ((MethodCallExpression)action.Body).Method.Name;
            var controllerName = action.Parameters[0].Type.Name.Replace("Controller", "");
            var resourceFor = ResourceFor(typeof(CommandResource), controllerName + "_" + actionName);
            return resourceFor;
        }
    }
}