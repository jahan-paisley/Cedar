using System;
using System.Collections.Generic;
using NUnit.Framework;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Data.Infrastructure;
using Cedar.WebPortal.Domain;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Cedar.WebPortal.Data.Test
{
    public class Gallery_Test
    {
        #region Public Methods

        private static Attachment CreateAttachmentStub()
        {
            return new Attachment
                       {
                           AttachmentId = Guid.NewGuid(),
                           ContentLength = (new Randomizer()).GetInts(0, 1000, 1)[0],
                           ContentType = "image/jpg",
                           Contents = new byte[10],
                           DateAdded = DateTime.Now,
                           FileName = "Test attachment"
                       };
        }

        public static Gallery FakeGallery()
        {
            var attachments = new List<Attachment>();

            for (int i = 0; i < 3; i++)
            {
                attachments.Add(CreateAttachmentStub());
            }
            var gallery = new Gallery
                              {
                                  GalleryId = Guid.NewGuid(),
                                  Attachments = attachments,
                                  CaptureDate = DateTime.Now,
                                  AppearInHomePage = false,
                                  Code = 2,
                                  Contents = "Test Content",
                                  Title = "Test",
                                  Published = true,
                                  PublishDate = DateTime.Now
                              };
            return gallery;
        }

        [Fact]
        public void Create_Gallery()
        {
            Gallery gallery = FakeGallery();

            var factory = new NHDatabaseFactory();

            foreach (var item in gallery.Attachments)
            {
                factory.CedarContext.Save(item);
            }

            factory.CedarContext.Save(gallery);
            factory.CedarContext.Commit();

            var find = factory.CedarContext.Get<Gallery>(gallery.GalleryId);
            Assert.IsTrue(find.IsNotNull());
            Assert.IsTrue(find.Attachments.Count == 3);
        }

        #endregion
    }
}