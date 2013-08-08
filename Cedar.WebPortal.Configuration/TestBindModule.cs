namespace Cedar.WebPortal.Configuration
{
    using System.Web.Mvc;
    using System.Web.Security;

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

    public class TestBindModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            this.Bind(typeof(ServiceBase<,>)).ToSelf().InThreadScope().Intercept().With<LoggingInterceptor>();
            this.Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
            #region Membership Providers
#if DEBUG
//            this.Bind<MembershipProvider>().ToProvider<SQLiteMembershipProvider>();
//            this.Bind<RoleProvider>().ToProvider<SQLiteRoleProvider>();
#else
            this.Bind<MembershipProvider>().ToConstant(Membership.Providers["SqlMembershipProvider"]);
            this.Bind<RoleProvider>().ToConstant(Roles.Providers["SqlRoleProvider"]);
#endif
            #endregion
            this.Bind<IEmailService>().To<EmailService>().InSingletonScope();
            this.Bind<INewsRepository>().To<NewsRepository>().InThreadScope();
            this.Bind<IAttachmentRepository>().To<AttachmentRepository>().InThreadScope();
            this.Bind<INewsService>().To<NewsService>().InThreadScope();
            this.Bind<IAttachmentService>().To<AttachmentService>().InThreadScope();
        }
        #endregion
    }
}