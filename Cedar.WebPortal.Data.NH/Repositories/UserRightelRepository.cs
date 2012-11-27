namespace Cedar.WebPortal.Data
{
    using System;
    using System.Linq;

    using NHibernate.Linq;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Domain;

    public class UserRightelRepository : RepositoryBase<UserRightel>, IUserRightelRepository
    {
        #region Constructors and Destructors

        public UserRightelRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        #region Implemented Interfaces

        #region IUserRightelRepository

        #endregion

        #region IRepository<UserRightel>

        public override void Add(UserRightel entity)
        {
            entity.CaptureData = DateTime.Now;
            base.Add(entity);
        }

        #endregion

        #endregion

        #region Methods


        #endregion
    }
}