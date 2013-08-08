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

        void Delete<T>(object id) where T : class, new();

        void Delete<T>(Func<T, bool> func) where T : class;

        T Get<T>(object id) where T : class;

        IQueryable<T> Query<T>() where T : class;

        void Save<T>(T obj) where T : class;

        void Update<T>(T obj) where T : class;

        T GetQuery<T>(string name, Dictionary<string, object> parameters) where T : class;

        #endregion
    }
}