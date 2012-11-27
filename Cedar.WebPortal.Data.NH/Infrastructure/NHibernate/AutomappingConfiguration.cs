//namespace Cedar.WebPortal.Data
//{
//    using System;
//    using System.Linq;

//    using FluentNHibernate;
//    using FluentNHibernate.Automapping;
//    using FluentNHibernate.Cfg;
//    using FluentNHibernate.Cfg.Db;

//    using NHibernate;
//    using NHibernate.Tool.hbm2ddl;

//    using Cedar.WebPortal.Domain;

//    /// <summary>
//    /// This is an example automapping configuration. You should create your own that either
//    /// implements IAutomappingConfiguration directly, or inherits from DefaultAutomappingConfiguration.
//    /// Overriding methods in this class will alter how the automapper behaves.
//    /// </summary>
//    internal class AutoMappingConfiguration : DefaultAutomappingConfiguration
//    {
//        #region Constants and Fields

//        private const string domainNamespace = "Cedar.WebPortal.Domain";

//        private const string id = "Id";

//        #endregion

//        #region Public Methods

//        public override bool IsComponent(Type type)
//        {
//            // override this method to specify which types should be treated as components
//            // if you have a large list of types, you should consider maintaining a list of them
//            // somewhere or using some form of conventional and/or attribute design
//            var components = new[] { typeof(DistributorAddress), typeof(MilitaryServiceInfo), typeof(SocialSecurityInfo), typeof(User), typeof(TenderAddress) };
//            return components.Any(o => o == type);
//        }

//        public override bool IsId(Member member)
//        {
//            return member.Name == member.DeclaringType.Name + id;
//        }

//        public override bool ShouldMap(Type type)
//        {
//            // specify the criteria that types must meet in order to be mapped
//            // any type for which this method returns false will not be mapped.
//            return type.Namespace == domainNamespace && !type.IsEnum;
//        }

//        #endregion

//        #region Methods

//        internal static ISessionFactory BuildSessionFactory()
//        {
//            log4net.Config.XmlConfigurator.Configure();

//            FluentConfiguration fluentConfiguration =
//                Fluently.Configure()
//                        .Database(
//                            MsSqlConfiguration
//                                .MsSql2008
//                                .ShowSql()
//                                .ConnectionString(o => o.FromConnectionStringWithKey("CedarContext")))
//                        .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
//              // .ExposeConfiguration(o=> new SchemaExport(o).Create(true, true))
//            ;

//            return fluentConfiguration.BuildSessionFactory();
//        }

//        internal static ISessionFactory BuildSqliteSessionFactory()
//        {
//            log4net.Config.XmlConfigurator.Configure();

//            var fluentConfiguration =
//                Fluently.Configure()
//                        .Database(
//                            SQLiteConfiguration
//                            .Standard
//                            .ShowSql()
//                            .ConnectionString(o => o.FromConnectionStringWithKey("SqliteCedarContext")))
//                        .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
////                 .ExposeConfiguration(o=> new SchemaExport(o).Create(true, true))
//            ;
//            return fluentConfiguration.BuildSessionFactory();
//        }


//        private static AutoPersistenceModel CreateAutomappings()
//        {
//            // This is the actual automapping - use AutoMap to start automapping,
//            // then pick one of the static methods to specify what to map (in this case
//            // all the classes in the assembly that contains Employee), and then either
//            // use the Setup and Where methods to restrict that behaviour, or (preferably)
//            // supply a configuration instance of your definition to control the automapper.

//            var autoPersistenceModel = AutoMap.AssemblyOf<Gender>(new AutoMappingConfiguration())
//                                              .Conventions.Add<Conventions>()
//                                              .UseOverridesFromAssemblyOf<DistributorMappingOverride>()//redundant just for beeing sure of stupid stuff
//                                              .UseOverridesFromAssemblyOf<UserRightelMappingOverride>()
//                                              .UseOverridesFromAssemblyOf<GalleryMappingOverride>()
//                                              .UseOverridesFromAssemblyOf<LocationMappingOverride>()
//                                              .UseOverridesFromAssemblyOf<DepartmentMappingOverride>()
//                                              .UseOverridesFromAssemblyOf<TicketMappingOverride>()
//                                              .UseOverridesFromAssemblyOf<NewsMappingOverride>();

//            autoPersistenceModel.Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Always());

//            return autoPersistenceModel;
//        }

//        #endregion
//    }
//}