using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cedar.WebPortal.Data.Common;

namespace Cedar.WebPortal.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class, new()
    {
        #region Constants and Fields

        private readonly IQueryable<T> dbset;

        private readonly ICedarContext CedarContext;

        #endregion

        #region Constructors and Destructors

        protected RepositoryBase(ICedarContext cedarContext)
        {
            CedarContext = cedarContext;
            dbset = DataContext.Query<T>();
        }

        #endregion

        #region Properties

        protected ICedarContext DataContext
        {
            get { return CedarContext; }
        }

        #endregion

        #region Implemented Interfaces

        #region IRepository<T>

        public virtual void Add(T entity)
        {
            BeforeSave(entity);
            DataContext.Save(entity);
        }

        public virtual void Delete(T entity)
        {
            DataContext.Delete(entity);
        }

        public void Delete(Guid id)
        {
            DataContext.Delete<T>(id);
        }

        public virtual void Delete(Expression<Func<T, Boolean>> where)
        {
            IEnumerable<T> objects = dbset.Where(where).AsEnumerable();
            foreach (T obj in objects)
            {
                Delete(obj);
            }
        }

        public virtual T Get(Expression<Func<T, Boolean>> where)
        {
            return dbset.FirstOrDefault(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual T GetById(Guid id)
        {
            return DataContext.Get<T>(id);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        public virtual void Save(T arg)
        {
            BeforeSave(arg);
            DataContext.Update(arg);
        }

        public virtual T ExequteSp(string nameParam, Dictionary<string, object> paramsValue)
        {
            return DataContext.GetQuery<T>(nameParam, paramsValue);
        }

        protected virtual void BeforeSave(T arg)
        {
        }

        #endregion

        #endregion
    }
}