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

    public class BindModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(ServiceBase<,>)).ToSelf().InRequestScope().Intercept().With<LoggingInterceptor>();
            this.Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
            #region Membership Providers
//#if DEBUG
//            this.Bind<MembershipProvider>().ToProvider<SQLiteMembershipProvider>();
//            this.Bind<RoleProvider>().ToProvider<SQLiteRoleProvider>();
//#else
            //this.Bind<ExtendedMembershipProvider>().ToConstant(SimpleMembership.Providers["SqlMembershipProvider"]);
           // this.Bind<RoleProvider>().ToConstant(Roles.Providers["SqlRoleProvider"]);
//#endif
            #endregion
            this.Bind<IEmailService>().To<EmailService>().InSingletonScope();
            this.Bind<INewsRepository>().To<NewsRepository>().InRequestScope();
            this.Bind<IAttachmentRepository>().To<AttachmentRepository>().InRequestScope();
            this.Bind<INewsService>().To<NewsService>().InRequestScope();
            this.Bind<IAttachmentService>().To<AttachmentService>().InRequestScope();
            this.Bind<IWebSecurityService>().To<WebSecurityService>().InRequestScope();
            this.Bind<ICedarContext>().To<CedarContext>().InRequestScope();
        }

        #endregion
    }
}