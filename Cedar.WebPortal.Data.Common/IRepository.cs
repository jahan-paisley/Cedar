namespace Cedar.WebPortal.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
        where T : class
    {
        #region Public Methods

        void Add(T entity);

        void Delete(T entity);

        void Delete(Guid id);

        void Delete(Expression<Func<T, Boolean>> predicate);

        T Get(Expression<Func<T, Boolean>> where);

        IEnumerable<T> GetAll();

        T GetById(Guid id);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Save(T arg);

        T ExequteSp(string nameParam, Dictionary<string,object> paramsValue);

        #endregion
    }
}