using System.Linq.Expressions;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain;

namespace Cedar.WebPortal.WebMVC4.Helper
{
    using System;
    using System.Collections.Generic;

    using System.Web.Mvc;

    using System.Web.Routing;

    public static class HtmlHelperExtensionsForFile
    {
        /// <summary>
        /// Returns a file input element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="member">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.FileBox(name, (object)null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="member">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return htmlHelper.FileBox(name, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="member">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileBox(this HtmlHelper htmlHelper, string name, IDictionary<String, Object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", "file", true);
            tagBuilder.MergeAttribute("name", name, true);
            tagBuilder.GenerateId(name);

            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="member">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static MvcHtmlString qqFileUploaderBox<TItem>(this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, Attachment>> expression)
        {
            string propname = htmlHelper.ViewData.Model.Item(expression);
            var tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttribute("name", propname, true);
            tagBuilder.MergeAttribute("class", "qqFileUpload", true);
            tagBuilder.GenerateId(propname);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
}