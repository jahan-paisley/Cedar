namespace Cedar.WebPortal.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NHibernate;
    using NHibernate.Linq;

    using Cedar.WebPortal.Data.Common;

    public class NHibernateContext : ICedarContext
    {
        #region Constructors and Destructors

        public NHibernateContext(ISession session)
        {
            this.Session = session;
        }

        #endregion

        #region Properties

        private ISession Session { get; set; }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        public void Dispose()
        {
            this.Session.Dispose();
        }

        #endregion

        #region ICedarContext

        public void Commit()
        {
            this.Session.Transaction.Commit();
        }

        public void Delete(object obj)
        {
            this.Session.Delete(obj);
        }

        public void Delete<T>(Guid id)
        {
            this.Session.Delete(typeof(T).FullName, this.Session.Load<T>(id));
        }

        public void Delete<T>(Func<T, bool> obj)
        {
            IEnumerable<T> enumerable = this.Query<T>().Where(obj);
            foreach (T variable in enumerable)
            {
                this.Session.Delete(variable);
            }
        }

        public T Get<T>(object id)
        {
            return this.Session.Get<T>(id);
        }

        public T Load<T>(object id)
        {
            return this.Session.Load<T>(id);
        }

        public object Merge(object obj)
        {
            return this.Session.Merge(obj);
        }

        public void Persist(object obj)
        {
            this.Session.Persist(obj);
        }

        public IQueryable<T> Query<T>()
        {
            return this.Session.Query<T>();
        }

        public T GetQuery<T>(string name, Dictionary<string, object> parameters)
        {
            Session.BeginTransaction();
            var query = this.Session.GetNamedQuery(name);
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    query.SetParameter(parameter.Key, parameter.Value);
                }
                else
                {
                    
                    query.SetParameter(parameter.Key, null, NHibernateUtil.String);
                }

            }
            Session.Transaction.Commit();
            return query.UniqueResult<T>();
        }



        public void Refresh(object obj)
        {
            this.Session.Refresh(obj);
        }

        public object Save(object obj)
        {
            return this.Session.Save(obj);
        }

        public void SaveOrUpdate(object obj)
        {
            this.Session.SaveOrUpdate(obj);
        }

        public void Update<T>(T obj)
        {
            this.Session.Update(obj);
        }

        #endregion

        #endregion
    }
}