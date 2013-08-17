namespace Cedar.WebPortal.Data.Infrastructure
{
    using Cedar.WebPortal.Data.Common;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICedarContext cedarContext;

        public UnitOfWork(ICedarContext cedarContext)
        {
            this.cedarContext = cedarContext;
        }
        
        #region IUnitOfWork Members

        public void Commit()
        {
            cedarContext.Commit();
        }

        #endregion
    }
}