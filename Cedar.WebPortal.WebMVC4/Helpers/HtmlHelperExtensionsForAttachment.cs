using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Domain;
using Cedar.WebPortal.WebMVC4.Controllers;

namespace Cedar.WebPortal.WebMVC4.Helpers
{
    public static class HtmlHelperExtensionsForAttachment
    {
        #region Public Methods

        public static MvcHtmlString Attachment<TItem>(
            this HtmlHelper<TItem> htmlHelper, Attachment expression) where TItem : class
        {
            Attachment attachment = expression;
            if (attachment.IsNotNull())
            {
                RouteValueDictionary routeValueDictionary =
                    htmlHelper.ViewContext.HttpContext.Request.RequestContext.RouteData.Values;
                if (routeValueDictionary.ContainsValue("Gallery") || routeValueDictionary.ContainsValue("gallery")
                    || (routeValueDictionary.ContainsValue("ListPaginationGallery") && routeValueDictionary.ContainsValue("Home"))
                    || (routeValueDictionary.ContainsValue("PictureGallery") && routeValueDictionary.ContainsValue("Home")))
                {
                    return
                        htmlHelper.Image(
                            UrlHelper(htmlHelper).Action("Index", "Attachment", new { Id = attachment.AttachmentId }),
                            new { heigth = "72px", width = "72px" });
                }
                return htmlHelper.ActionLink((AttachmentController o) => o.Index(attachment.AttachmentId));
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString Attachment<TItem>(
            this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, Attachment>> expression) where TItem : class
        {
            string propname = htmlHelper.ViewData.Model.Item(expression);
            Attachment attachment = htmlHelper.ViewData.Model.GetProperty<TItem, Attachment>(propname);
            if (attachment.IsNotNull())
            {
                return htmlHelper.ActionLink((AttachmentController o) => o.Index(attachment.AttachmentId));
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString DisplayAttachment<TItem>(this HtmlHelper<TItem> htmlHelper,
                                                             Expression<Func<TItem, Attachment>> expression)
        {
            string propname = htmlHelper.ViewData.Model.Item(expression);
            return DisplayAttachment(htmlHelper, propname);
        }

        public static MvcHtmlString DisplayAttachment<TItem>(
            this HtmlHelper htmlHelper, TItem item, Expression<Func<TItem, Attachment>> expression) where TItem : class
        {
            if (item.IsNull())
            {
                return MvcHtmlString.Empty;
            }

            string propname = item.Item(expression);
            //Attachment attachment;
            //if (propname!="Attachment")
            //{
            var attachment = item.GetProperty(propname) as Attachment;
            //}
            //else
            //{
            //    attachment = item as Attachment;
            //}

            if (attachment != null && attachment.AttachmentId != Guid.Empty && attachment.Contents != null)
            {
                RouteValueDictionary routeValueDictionary =
                    htmlHelper.ViewContext.HttpContext.Request.RequestContext.RouteData.Values;
                if (routeValueDictionary.ContainsValue("News") || routeValueDictionary.ContainsValue("Home") ||
                    routeValueDictionary.ContainsValue("news"))
                {
                    return
                        htmlHelper.Image(
                            UrlHelper(htmlHelper).Action("Index", "Attachment", new { Id = attachment.AttachmentId }));
                    //,new {heigth = "450px", width = "60px"});
                }
                return htmlHelper.ActionLink((AttachmentController o) => o.Index(attachment.AttachmentId));
            }
            return MvcHtmlString.Empty;
        }

//        public static MvcHtmlString AttachmentDiv<TItem>(
//           this HtmlHelper<TItem> htmlHelper, Expression<Func<TItem, Attachment>> expression) where TItem : class
//        {
//            var docName = htmlHelper.ViewData.Model.Item(expression);
//            var doc = htmlHelper.ViewData.Model.GetProperty<TItem, Attachment>(docName);
//            var docId = docName + "Id";
//            string firstPart = String.Format(@"<div class='attachment'><div style='float: right;width: 50%;'>
//                                            <b>{0}</b></div><div style='float: left;width: 50%;'>", htmlHelper.LabelFor(expression));
//            string middlePart = string.Empty;
//            if (doc.IsNotNull())
//            {
//                middlePart = String.Format(@"<div type='file' name='{0}' id='{0}'</div>
//                                                     <a href='javascript:void(0)' class='linkDelete' 
//                                                     onClick='deleteFile('{1}','{0}');' >حذف</a>
//                                                     Html.Raw('&nbsp;&nbsp;');<input type='hidden' name='{2}' id='{2}' 
//                                                     value='{1}'/>", docName, doc.AttachmentId, docId);

//            }
//            else
//            {
//                middlePart = string.Format(@"<div type='file' name='{0}' id='{0}' ></div>", docName);
//            }
//            string endPart =string.Format( @"<div class='link'> {0}</div><div class='span'>&nbsp;</div></div></div>"
//                , htmlHelper.DisplayAttachment(htmlHelper.ViewData.Model, expression));
//                return MvcHtmlString.Create(firstPart+middlePart+endPart);
           
//        }
        #endregion

        #region Methods

        public static MvcHtmlString DisplayAttachment(HtmlHelper htmlHelper, string attachment1)
        {
            object model = htmlHelper.ViewData.Model;
            var attachment = model.GetProperty(attachment1) as Attachment;
            if (attachment != null)
            {
                if (attachment.ContentType.Contains("image"))
                {
                    return
                        htmlHelper.Image(
                            UrlHelper(htmlHelper).Action("Index", "Attachment", new { Id = attachment.AttachmentId }),
                            new { heigth = "80px", width = "60px" });
                }
                else
                {
                    return htmlHelper.ActionLink((AttachmentController o) => o.Index(attachment.AttachmentId));
                }
            }
            return MvcHtmlString.Empty;
        }

        private static UrlHelper UrlHelper(HtmlHelper htmlHelper)
        {
            var urlHelper =
                new UrlHelper(
                    new RequestContext(
                        htmlHelper.ViewContext.HttpContext,
                        htmlHelper.RouteCollection.GetRouteData(htmlHelper.ViewContext.HttpContext)),
                    htmlHelper.RouteCollection);
            return urlHelper;
        }

        #endregion
    }
}