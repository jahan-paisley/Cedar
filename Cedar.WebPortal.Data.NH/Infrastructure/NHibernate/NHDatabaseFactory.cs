using System;
using Cedar.WebPortal.Common;
using Cedar.WebPortal.Data.Common;
using Cedar.WebPortal.Domain;
using NHibernate;
using Xunit;
using log4net.Config;

namespace Cedar.WebPortal.Data.Infrastructure
{
    public class NHDatabaseFactory : Disposable, IDatabaseFactory
    {
        #region Constants and Fields

        private static readonly ISessionFactory sessionFactory = MyAutoMapper.BuildSessionFactory();

        private readonly ICedarContext dataContext;

        private readonly ISession session;

        #endregion

        #region Constructors and Destructors

        public NHDatabaseFactory()
        {
            session = sessionFactory.OpenSession();
            session.BeginTransaction();

            session.FlushMode = FlushMode.Commit;
            dataContext = new NHibernateContext(session);
        }

        #endregion

        #region Properties

        public ICedarContext CedarContext
        {
            get { return dataContext; }
        }

        #endregion

        #region Public Methods

        [Fact]
        public void Test()
        {
            XmlConfigurator.Configure();
            ISession openSession = sessionFactory.OpenSession();
            //            Applicant applicant = openSession.Query<Applicant>().First();
            var load = openSession.Load<Applicant>(new Guid("97EA408C-EF0B-47BD-8AAC-9F140005ED44"));
            Assert.True(load.Picture.IsNotNull());
        }

        #endregion

        #region Methods

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }

        #endregion
    }
}