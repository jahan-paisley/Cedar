namespace Cedar.WebPortal.Configuration
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class CustomControllerActivator : IControllerActivator
    {
        #region Implemented Interfaces

        #region IControllerActivator

        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
           // new NinjectDependencyScope(requestContext).GetService(controllerType);
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }

        #endregion

        #endregion
    }
}