namespace Cedar.WebPortal.Configuration
{
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using Ninject.Modules;
    using Ninject.Web.Common;

    using Cedar.WebPortal.Data;
    using Cedar.WebPortal.Data.Common;
    using Cedar.WebPortal.Data.Infrastructure;
    using Cedar.WebPortal.Logging;
    using Cedar.WebPortal.Service;
    using Cedar.WebPortal.Service.Common;
    using Cedar.WebPortal.Service.Infrastructure;

    /// <summary>
    /// Define binding of interfaces to implementations, Adding Interceptors 
    /// </summary>
    public class BindModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            SimpleMembershipMVC4.Start();

            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();

            //this.Bind<ExtendedMembershipProvider>().ToConstant(SimpleMembership.Providers["SqlMembershipProvider"]);
            //this.Bind<RoleProvider>().ToConstant(Roles.Providers["SqlRoleProvider"]);

            this.Bind<IEmailService>().To<EmailService>().InSingletonScope();
            this.Bind<INewsRepository>().To<NewsRepository>().InRequestScope();
            this.Bind<IAttachmentRepository>().To<AttachmentRepository>().InRequestScope();

            this.Bind<INewsService>().To<NewsService>().InRequestScope().Intercept().With<LoggingInterceptor>();
            
            this.Bind<IAttachmentService>().To<AttachmentService>().InRequestScope();
            this.Bind<IWebSecurityService>().To<WebSecurityService>().InRequestScope();
            this.Bind<ICedarContext>().To<CedarContext>().InRequestScope();
        }

        #endregion
    }
}