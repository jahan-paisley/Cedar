using System.Collections.Generic;

namespace Cedar.WebPortal.Data.Common
{
    using System;
    using System.Linq;

    public interface ICedarContext : IDisposable
    {
        #region Public Methods

        void Commit();

        void Delete(object obj);

        void Delete<T>(Guid id);

        void Delete<T>(Func<T, bool> obj);

        T Get<T>(object id);

        T Load<T>(object id);

        object Merge(object obj);

        void Persist(object obj);

        IQueryable<T> Query<T>();

        void Refresh(object obj);

        object Save(object obj);

        void SaveOrUpdate(object obj);

        void Update<T>(T obj);

        T GetQuery<T>(string name, Dictionary<string, object> parameters);

        #endregion
    }
}