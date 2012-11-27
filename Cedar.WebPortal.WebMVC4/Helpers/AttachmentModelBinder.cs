namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Domain;

    public class AttachmentModelBinder : IModelBinder
    {
        #region Implemented Interfaces

        #region IModelBinder

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Attachment attachment;
            HttpRequestBase httpRequestBase = controllerContext.RequestContext.HttpContext.Request;
            if (!String.IsNullOrEmpty(httpRequestBase["qqfile"]))
            {
                attachment = new Attachment()
                              {
                                  ContentLength = httpRequestBase.ContentLength,
                                  ContentType = httpRequestBase.ContentType,
                                  DateAdded = DateTime.Now,
                                  FileName = httpRequestBase["qqfile"],
                                  Contents = new byte[httpRequestBase.ContentLength]
                              };
                httpRequestBase.InputStream.Read(attachment.Contents, 0, httpRequestBase.ContentLength);

            }
            else
            {
                HttpPostedFileBase @base = controllerContext.RequestContext.RouteData.Values.ContainsValue("AsyncUpload")
                                               ? httpRequestBase.Files[0]
                                               : httpRequestBase.Files[bindingContext.ModelName];
                var converter = new FileConverter();
                attachment = converter.Convert(
                    new ResolutionContext(
                        new TypeMap(new TypeInfo(typeof(HttpPostedFileWrapper)), new TypeInfo(typeof(Attachment)),MemberList.Destination),
                        @base,
                        typeof(HttpPostedFileWrapper),
                        typeof(Attachment),null));
            }
            Guid attachmentId;
            Guid.TryParse(httpRequestBase.Form[bindingContext.ModelName + "Id"], out attachmentId);
            if (attachmentId == Guid.Empty && attachment == null)
            {
                return null;
            }
            if (attachmentId != Guid.Empty && attachment.IsNull())
            {
                return new Attachment { AttachmentId = attachmentId };
            }
            if (attachmentId != Guid.Empty && attachment.IsNotNull())
            {
                attachment.AttachmentId = attachmentId;
                return attachment;
            }
            if (attachment.AttachmentId == Guid.Empty && attachment.ContentLength > 0)
            {
                return attachment;
            }
            return null;
        }

        #endregion

        #endregion
    }
}