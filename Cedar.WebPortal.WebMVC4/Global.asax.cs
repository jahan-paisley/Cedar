namespace Cedar.WebPortal.WebMVC4
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using Cedar.WebPortal.Domain.Entities;
    using Cedar.WebPortal.WebMVC4.Helpers;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        #region Methods

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(Attachment), new AttachmentModelBinder()));
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(DateTime), new DateTimeModelBinder()));
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(DateTime?), new DateTimeModelBinder()));
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(IEnumerable<SelectListItem>), new DropdownListBinder()));
            Mapper.Initialize(cfg => cfg.AddProfile<ViewModelProfile>());
        }

        #endregion
    }
}