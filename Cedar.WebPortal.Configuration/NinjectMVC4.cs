namespace Cedar.WebPortal.Configuration
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// Ninject Bootstraper called on ASP.NET MVC Application start/stop as defined in AssemblyInfo.cs file in the Web project.cs   
    /// </summary>
    public static class NinjectMVC4
    {
        #region Constants and Fields

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        #endregion

        #region Public Methods

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new[] { new BindModule() });
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        private static void RegisterServices(IKernel kernel)
        {
        }

        #endregion
    }
}