namespace Cedar.WebPortal.Logging
{
    using Ninject.Extensions.Interception;
    using Ninject.Extensions.Interception.Attributes;
    using Ninject.Extensions.Interception.Request;
    using Ninject;

    public class LogMyCallsAttribute : InterceptAttribute
    {
        #region Public Methods

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Context.Kernel.Get<LoggingInterceptor>() ;
        }

        #endregion
    }
}