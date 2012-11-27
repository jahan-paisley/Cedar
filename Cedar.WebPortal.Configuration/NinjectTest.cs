using Ninject.Web.Common;

namespace Cedar.WebPortal.Configuration
{
    using Ninject;
    using Ninject.Modules;

    public class NinjectTest
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        private static IKernel kernel;

        public static IKernel Kernel
        {
            get
            {
                return kernel ?? CreateKernel();
            }
            set
            {
                kernel = value;
            }
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            CreateKernel();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var modules = new NinjectModule[] { new TestBindModule() };
            var kernel = new StandardKernel(modules);

            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }

    }
}