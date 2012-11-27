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

    using WebMatrix.WebData;

    public class BindModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            //this.Bind<IControllerActivator>().To<CustomControllerActivator>().InRequestScope();
            this.Bind<IDatabaseFactory>().To<NHDatabaseFactory>().InRequestScope();
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
            this.Bind<IGalleryRepository>().To<GalleryRepository>().InRequestScope();
            this.Bind<IMessageRepository>().To<MessageRepository>().InRequestScope();
            this.Bind<IApplicantRepository>().To<ApplicantRepository>().InRequestScope();
            this.Bind<IJobPositionRepository>().To<JobPositionRepository>().InRequestScope();
            this.Bind<IAttachmentRepository>().To<AttachmentRepository>().InRequestScope();
            this.Bind<ILocationRepository>().To<LocationRepository>().InRequestScope();
            this.Bind<IDepartmentRepository>().To<DepartmentRepository>().InRequestScope();

            this.Bind<INewsService>().To<NewsService>().InRequestScope();
            this.Bind<IGalleryService>().To<GalleryService>().InRequestScope();
            this.Bind<IMessageService>().To<MessageService>().InRequestScope();
            this.Bind<IApplicantService>().To<ApplicantService>().InRequestScope();
            this.Bind<IJobPositionService>().To<JobPositionService>().InRequestScope();
            this.Bind<IAttachmentService>().To<AttachmentService>().InRequestScope();
            this.Bind<ILocationService>().To<LocationService>().InRequestScope();
            this.Bind<IDepartmentService>().To<DepartmentService>().InRequestScope();
            this.Bind<ICedarContext>().To<NHibernateContext>().InRequestScope();
            this.Bind<IWebSecurityService>().To<WebSecurityService>().InRequestScope();

        }

        #endregion
    }
}