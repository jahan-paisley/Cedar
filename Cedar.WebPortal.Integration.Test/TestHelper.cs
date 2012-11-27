namespace Cedar.WebPortal.Integration.Test
{
    using Ninject;

    using Cedar.WebPortal.Configuration;
    using Xunit;

    public static class TestHelper
    {
        internal static IKernel kernel;

        static TestHelper()
        {
            NinjectTest.Start();
            kernel = NinjectTest.Kernel;
            Assert.True(kernel != null);
        }
    }
}
