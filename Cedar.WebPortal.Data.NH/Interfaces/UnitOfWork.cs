namespace Cedar.WebPortal.Data.Infrastructure
{
    using Cedar.WebPortal.Data.Common;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }


        #region IUnitOfWork Members

        public void Commit()
        {
            databaseFactory.CedarContext.Commit();
        }

        #endregion
    }
}