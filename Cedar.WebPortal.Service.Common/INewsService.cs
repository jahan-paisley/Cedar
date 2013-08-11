namespace Cedar.WebPortal.Service.Common
{
    using System;
    using System.Collections.Generic;

    using Cedar.WebPortal.Domain.Entities;

    public interface INewsService : IServiceBase<News>
    {
        #region Public Methods

        IEnumerable<News> GetPublishedNews();

        IEnumerable<News> GetNewsForHomePage();

        News GetPublishedNews(Guid id);

        IEnumerable<News> GetUnpublishedNews();

        #endregion
    }
}