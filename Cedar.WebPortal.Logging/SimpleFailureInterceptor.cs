namespace Cedar.WebPortal.Logging
{
    using System;

    using Ninject.Extensions.Interception;

    public abstract class SimpleFailureInterceptor : IInterceptor
    {
        #region Implemented Interfaces

        #region IInterceptor

        public virtual void Intercept(IInvocation invocation)
        {
            try
            {
                this.BeforeInvoke(invocation);
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                this.OnError(invocation, ex);
            }
            finally
            {
                this.AfterInvoke(invocation);
            }
        }

        #endregion

        #endregion

        #region Methods

        protected virtual void AfterInvoke(IInvocation invocation)
        {
        }

        protected virtual void BeforeInvoke(IInvocation invocation)
        {
        }

        protected virtual void OnError(IInvocation invocation, Exception exception)
        {
            throw exception;
        }

        #endregion
    }
}