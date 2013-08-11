namespace Cedar.WebPortal.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain.Entities;
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

        public IEnumerable<News> GetNewsForHomePage()
        {
            IQueryable<News> news =
                this.GetMany(
                    o =>
                        o.Published && o.AppearInHomePage &&
                        (o.ExpirationDate == null || o.ExpirationDate >= DateTime.Now));
                //.OrderByDescending(o => o.CaptureDate);
            return news;
        }

        public virtual News GetPublishedNews(Guid id)
        {
            News news = this.GetById(id);
            return news;
        }

        public IEnumerable<News> GetPublishedNews()
        {
            IQueryable<News> news =
                this.GetMany(o => o.Published && (o.ExpirationDate == null || o.ExpirationDate >= DateTime.Now));
            return news;
        }

        public IEnumerable<News> GetUnpublishedNews()
        {
            IQueryable<News> news = this.GetMany(o => !o.Published);
            return news;
        }

        #endregion

        #region IServiceBase<News>

        public override IEnumerable<News> GetAll()
        {
            IOrderedEnumerable<News> news = base.GetAll().OrderByDescending(o => o.CreatedAt);
            return news;
        }

        #endregion

        #endregion
    }
}