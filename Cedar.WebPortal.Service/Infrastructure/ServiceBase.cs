namespace Cedar.WebPortal.Service.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Logging;
    using Cedar.WebPortal.Service.Common;

    public abstract class ServiceBase<TEntity, TIRepository> : IServiceBase<TEntity> where TEntity : class, new() 
                                                                                           where TIRepository : IRepository<TEntity>
    {
        #region Constructors and Destructors

        protected ServiceBase(TIRepository repository, IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.Repository = repository;
        }

        #endregion

        #region Properties

        public virtual TIRepository Repository { get; set; }

        public virtual IUnitOfWork UnitOfWork { get; set; }

        #endregion

        #region Implemented Interfaces

        #region IServiceBase<TEntity>

        public virtual void Add(TEntity entity)
        {
            this.Repository.Add(entity);
            this.UnitOfWork.Commit();
        }

        public virtual void Delete(Guid id)
        {
            Repository.Delete(id);
            this.UnitOfWork.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            this.Repository.Delete(entity);
            this.UnitOfWork.Commit();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            this.Repository.Delete(predicate);
            this.UnitOfWork.Commit();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return this.Repository.Get(@where);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.Repository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return this.Repository.GetById(id);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where)
        {
            return this.Repository.GetMany(@where);
        }

        public virtual void Save(TEntity arg)
        {
            this.Repository.Save(arg);
            this.UnitOfWork.Commit();
        }

        public virtual TEntity ExequteSp(string namePram, Dictionary<string, object> paramsValue)
        {
           return Repository.ExequteSp(namePram, paramsValue);
        }

        #endregion

        #endregion
    }
}