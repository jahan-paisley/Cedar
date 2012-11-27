namespace Cedar.WebPortal.Data.Test
{
    using System;
//    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using Cedar.WebPortal.Domain;
//
//    [TestFixture]
//    public class NewsTest
//    {
//        #region Public Methods
//
//        [Test]
//        public void Update_Association_Test()
//        {
//            var context = new CedarContext();
//
//            context.Set<News>().ToList().ForEach(o=> context.Set<News>().Remove(o));
//            context.Set<Attachment>().ToList().ForEach(o=> context.Set<Attachment>().Remove(o));
//
//            News newsStub = CreateNewsStub();
//            context.News.Add(newsStub);
//            context.SaveChanges();
//            Debug.Indent();
//            Debug.Print(newsStub.Attachment.AttachmentId.ToString());
//            context.Dispose();
//
//            var context1 = new CedarContext();
//            News newsStub1 = context1.Set<News>().AsNoTracking().First(o => o.NewsId == newsStub.NewsId);
//            newsStub1.Attachment = CreateAttachmentStub();
//            var attach = newsStub1.Attachment;
//            context1.News.Attach(newsStub1);
//            context1.Attachment.Attach(newsStub1.Attachment);
//            //context1.Attachment.Attach(newsStub1.Attachment);
//            //context1.Entry(newsStub1.Attachment).State = System.Data.EntityState.Added;
//            //context1.Entry(newsStub1).State = System.Data.EntityState.Modified;
//            context1.Entry(newsStub1).Reference(o => o.Attachment).Load();
//            newsStub1.Attachment = attach;
//            context1.Entry(newsStub1).State = System.Data.EntityState.Modified;
//            context1.Entry(newsStub1.Attachment).State = System.Data.EntityState.Modified;
//
//            context1.SaveChanges();
//            Attachment currentVal = newsStub1.Attachment;
//            Debug.Print(currentVal.AttachmentId.ToString());
//            Attachment loadedVal =
//                context1.Set<Attachment>().AsNoTracking().FirstOrDefault(p => p.AttachmentId == currentVal.AttachmentId);
//            Assert.IsTrue(currentVal.Equals(loadedVal));
//        }
//
//        #endregion
//
//        #region Methods
//
//        private static Attachment CreateAttachmentStub()
//        {
//            return new Attachment
//                {
//                    AttachmentId = Guid.NewGuid(),
//                    ContentLength = (new Randomizer()).GetInts(0, 1000, 1)[0],
//                    ContentType = "image/jpg",
//                    Contents = new byte[10],
//                    DateAdded = DateTime.Now,
//                    FileName = "salam"
//                };
//        }
//
//        private static News CreateNewsStub()
//        {
//            return new News
//                {
//                    Attachment = CreateAttachmentStub(),
//                    NewsId = Guid.NewGuid(),
//                    CaptureDate = DateTime.Now,
//                    Code = 1,
//                    Contents = "salam alakom",
//                    PublishDate = DateTime.Now,
//                    Published = true,
//                    Title = "Title salam"
//                };
//        }
//
//        #endregion
//    }
}