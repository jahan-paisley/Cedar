namespace Cedar.WebPortal.Data.Infrastructure
{
    using System;

    using NHibernate;

    using Cedar.WebPortal.Common;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Domain;

    using Xunit;

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
            this.session = sessionFactory.OpenSession();
            this.session.BeginTransaction();

            this.session.FlushMode = FlushMode.Commit;
            this.dataContext = new NHibernateContext(this.session);
        }

        #endregion

        #region Properties

        public ICedarContext CedarContext
        {
            get
            {
                return this.dataContext;
            }
        }

        #endregion

        #region Public Methods

        [Fact]
        public void Test()
        {
            log4net.Config.XmlConfigurator.Configure();
            ISession openSession = sessionFactory.OpenSession();
            //            Applicant applicant = openSession.Query<Applicant>().First();
            var load = openSession.Load<Applicant>(new Guid("97EA408C-EF0B-47BD-8AAC-9F140005ED44"));
            Assert.True(load.Picture.IsNotNull());
        }

        #endregion

        #region Methods

        protected override void DisposeCore()
        {
            if (this.dataContext != null)
            {
                this.dataContext.Dispose();
            }
        }

        #endregion
    }
}