namespace Cedar.WebPortal.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cedar.WebPortal.Data;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.Service.Infrastructure;

    public class NewsService : ServiceBase<News, INewsRepository>, INewsService
    {
        #region Constructors and Destructors

        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork)
            : base(newsRepository, unitOfWork)
        {
        }

        #endregion

        #region Implemented Interfaces

        #region INewsService

        public News GetPublishedNews(Guid id)
        {
            var news = this.GetById(id);
            return news;
        }

        public IEnumerable<News> GetPublishedNews()
        {
            var news = this.GetMany(o => o.Published && (o.ExpirationDate==null || o.ExpirationDate >= DateTime.Now));
            return news;
        }

        public IEnumerable<News> GetUnpublishedNews()
        {
            var news = this.GetMany(o => !o.Published);
            return news;
        }

        public IEnumerable<News> GetNewsForHomePage()
        {
            var news = this.GetMany(o => o.Published && o.AppearInHomePage && (o.ExpirationDate == null || o.ExpirationDate >= DateTime.Now)).OrderByDescending(o => o.CaptureDate);
            return news;
        }

        public override IEnumerable<News> GetAll()
        {
            var news = base.GetAll().OrderByDescending(o => o.CaptureDate);
            return news;
        }

        #endregion

        #endregion
    }
}