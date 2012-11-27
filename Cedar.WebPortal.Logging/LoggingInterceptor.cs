namespace Cedar.WebPortal.Logging
{
    using System;

    using Ninject.Extensions.Interception;
    using Ninject.Extensions.Logging;

    public class LoggingInterceptor : SimpleFailureInterceptor
    {
        #region Constants and Fields

        private readonly ILogger _logger;

        private bool _hasError;

        #endregion

        #region Constructors and Destructors

        public LoggingInterceptor(ILogger logger)
        {
            this._logger = logger;
            this._hasError = false;
        }

        #endregion

        #region Methods

        protected override void AfterInvoke(IInvocation invocation)
        {
            this._logger.Info(
                "{0} finished {1}.",
                MethodNameFor(invocation),
                (this._hasError ? "with an error state" : "successfully"));
        }

        protected override void BeforeInvoke(IInvocation invocation)
        {
            this._logger.Info("{0}", MethodNameFor(invocation));
        }

        protected override void OnError(IInvocation invocation, Exception exception)
        {
            string sw = string.Format("********** {0} **********\n Message: {1}", DateTime.Now, exception.Message);
            if (exception.InnerException != null)
            {
                sw += string.Format(
                    "Inner Exception Type: {0} \n Inner Exception: {1} \n Inner Source: {2}",
                    exception.InnerException.GetType(),
                    exception.InnerException.Message,
                    exception.InnerException.Source);
                if (exception.InnerException.StackTrace != null)
                {
                    sw += string.Format("\n Inner Stack Trace: {0}", exception.InnerException.StackTrace);
                }
            }
            sw += string.Format(
                "\n Exception Type: {0}\n Exception: {1}\n Source: {2}\n Stack Trace: ",
                exception.GetType(),
                exception.Message,
                MethodNameFor(invocation));
            if (exception.StackTrace != null)
            {
                sw += (exception.StackTrace);
            }

            this._logger.Error(
                exception, "There was an error invoking {0} Error details is:{1}.\r\n", MethodNameFor(invocation), sw);

            this._hasError = true;
            base.OnError(invocation, exception);
        }

        private static string MethodNameFor(IInvocation invocation)
        {
            return invocation.Request.Method.ToString();
        }

        #endregion
    }
}