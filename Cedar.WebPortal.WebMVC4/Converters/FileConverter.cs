namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.IO;
    using System.Web;

    using AutoMapper;

    using Cedar.WebPortal.Domain;

    public class FileConverter : ITypeConverter<HttpPostedFileWrapper, Attachment>
    {
        #region Implemented Interfaces

        #region ITypeConverter<HttpPostedFileWrapper,Attachment>

        public Attachment Convert(ResolutionContext context)
        {
            var file = context.SourceValue as HttpPostedFileWrapper;
            return file == null ? null : GetAttachment(file);
        }

        #endregion

        #endregion

        #region Methods

        private static Attachment GetAttachment(HttpPostedFileBase fileBase)
        {
            if (fileBase.ContentLength == 0)
            {
                return null;
            }
            var buffer = new byte[fileBase.ContentLength];
            Stream stream = fileBase.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(buffer, 0, fileBase.ContentLength - 1);
            return new Attachment
                {
                    ContentLength = fileBase.ContentLength,
                    Contents = buffer,
                    ContentType = fileBase.ContentType,
                    DateAdded = DateTime.Now,
                    FileName = fileBase.FileName
                };
        }

        #endregion
    }
}