namespace Cedar.WebPortal.Service.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IServiceBase<T>
    {
        #region Public Methods

        void Add(T entity);

        void Delete(Guid id);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, Boolean>> where);

        IEnumerable<T> GetAll();

        T GetById(Guid Id);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Save(T arg);

        T ExequteSp(string namePram, Dictionary<string, object> paramsValue);

        #endregion
    }
}