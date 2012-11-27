// NHibernate mapping-by-code naming convention resembling Fluent's
// See the blog post: http://notherdev.blogspot.com/2012/01/mapping-by-code-naming-convention.html

namespace Cedar.WebPortal.Data
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Mapping.ByCode;

    using Cedar.WebPortal.Data;
    using Cedar.WebPortal.Domain;

    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Cfg.MappingSchema;
    using global::NHibernate.Dialect;
    using global::NHibernate.Mapping.ByCode;

    using Configuration = global::NHibernate.Cfg.Configuration;

    public class ModelMapperWithNamingConventions : ConventionModelMapper
    {
        #region Constants and Fields

        public const char ElementColumnTrimmedPluralPostfix = 's';

        public const string ForeignKeyColumnPostfix = "_id";

        public const string ManyToManyIntermediateTableInfix = "To";

        private const string ComponentNamespace = "TaminTelecom.WebPortal.Domain.Component";

        private const string DomainNamespace = "TaminTelecom.WebPortal.Domain";

        private readonly List<MemberInfo> _ignoredMembers = new List<MemberInfo>();

        #endregion

        #region Constructors and Destructors

        public ModelMapperWithNamingConventions()
        {
            this.BeforeMapManyToOne +=
                (inspector, member, customizer) => customizer.Column(member.LocalMember.Name + ForeignKeyColumnPostfix);
            this.BeforeMapManyToMany +=
                (inspector, member, customizer) =>
                customizer.Column(member.CollectionElementType().Name + ForeignKeyColumnPostfix);
            this.BeforeMapElement +=
                (inspector, member, customizer) =>
                customizer.Column(member.LocalMember.Name.TrimEnd(ElementColumnTrimmedPluralPostfix));
            this.BeforeMapJoinedSubclass +=
                (inspector, type, customizer) => customizer.Key(k => k.Column(type.BaseType.Name + ForeignKeyColumnPostfix));

            this.BeforeMapSet += this.BeforeMappingCollectionConvention;
            this.BeforeMapBag += this.BeforeMappingCollectionConvention;
            this.BeforeMapList += this.BeforeMappingCollectionConvention;
            this.BeforeMapIdBag += this.BeforeMappingCollectionConvention;
            this.BeforeMapMap += this.BeforeMappingCollectionConvention;

            this.BeforeMapComponent += this.DisableComponentParentAutomapping;

            this.IsPersistentProperty((m, d) => !this._ignoredMembers.Contains(m));
        }

        #endregion

        #region Methods

        internal static ISessionFactory BuildSessionFactory()
        {
            var mapper = new ModelMapperWithNamingConventions();
            Type[] exportedTypes = typeof(Applicant).Assembly.GetExportedTypes();

            mapper.IsProperty(IsProperty);
            mapper.IsEntity(IsEntity);
            mapper.IsManyToMany(IsManyToMany);
            //mapper.IsComponent(IsComponent);

            mapper.AddMapping<LocationMapOverride>();
            mapper.AddMapping<NewsMappingOverride>();

            mapper.AddMapping<DistributorMapOverride>();
            mapper.AddMapping<GalleryMapOverride>();

            //mapper.AddMapping<ApplicantMapOverride>();

            HbmMapping map = mapper.CompileMappingFor(exportedTypes);

            var configure = new Configuration();

            //#if DEBUG
            //            configure.DataBaseIntegration(x =>
            //                {
            //                    x.Dialect<SQLiteDialect>();
            //                    x.ConnectionString =
            //                        ConfigurationManager.ConnectionStrings["SqliteTaminTelecomContext"].ToString();
            //                     x.SchemaAction = SchemaAutoAction.Update;
            //                });
            //#else
            //            configure.DataBaseIntegration(x =>
            //            {
            //                x.Dialect<MsSql2008Dialect>();
            //                x.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TaminTelecomContext"].ToString();
            //                x.SchemaAction = SchemaAutoAction.Create;
            //            });
            //#endif
            configure.DataBaseIntegration(
                x =>
                    {
                        x.Dialect<MsSql2008Dialect>();
                        x.ConnectionString = ConfigurationManager.ConnectionStrings["CedarContext"].ToString();
                        x.SchemaAction = SchemaAutoAction.Recreate;
                    });
            configure.AddDeserializedMapping(map, "CedarModel");
            return configure.BuildSessionFactory();
        }

        private static string DetermineKeyColumnName(IModelInspector inspector, PropertyPath member)
        {
            MemberInfo otherSideProperty = member.OneToManyOtherSideProperty();
            if (inspector.IsOneToMany(member.LocalMember) && otherSideProperty != null)
            {
                return otherSideProperty.Name + ForeignKeyColumnPostfix;
            }

            return member.Owner().Name + ForeignKeyColumnPostfix;
        }

        private static bool IsEntity(Type o, bool b)
        {
            return o.Namespace == DomainNamespace && !o.IsEnum;
        }

        private static bool IsManyCollection(PropertyInfo info)
        {
            return info.PropertyType.IsGenericCollection() && !info.PropertyType.IsArray;
        }

        private static bool IsProperty(MemberInfo member, bool u)
        {
            var propertyInfo = member as PropertyInfo;

            string ns = propertyInfo.PropertyType.Namespace;

            if (ns == DomainNamespace || ns == ComponentNamespace || IsManyCollection(propertyInfo))
            {
                return false;
            }

            if (member.Name != "Id") // property named id have to be mapped as keys...
            {
                if (propertyInfo.PropertyType.FullName.IndexOf("MappingByCode") == -1)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsManyToMany(MemberInfo memberInfo, bool b)
        {
            var propertyInfo = memberInfo as PropertyInfo;
            PropertyInfo[] propertyInfos = propertyInfo.PropertyType.GetGenericArguments()[0].GetProperties();
            string value = propertyInfo.DeclaringType.Name;
            if (IsManyCollection(propertyInfo) && !propertyInfos.Any(o => o.PropertyType.Name.Contains(value)))
            {
                return true;
            }
            return false;
        }

        private static bool IsComponent(MemberInfo memberInfo, bool b)
        {
            var propertyInfo = memberInfo as PropertyInfo;

            string ns = propertyInfo.PropertyType.Namespace;

            if (ns == ComponentNamespace)
            {
                return true;
            }
            return false;

        }

        private void BeforeMappingCollectionConvention(
            IModelInspector inspector, PropertyPath member, ICollectionPropertiesMapper customizer)
        {
            if (inspector.IsManyToMany(member.LocalMember))
            {
                customizer.Table(member.ManyToManyIntermediateTableName());
            }

            customizer.Key(k => k.Column(DetermineKeyColumnName(inspector, member)));
        }

        private void DisableAutomappingFor(MemberInfo member)
        {
            if (member != null)
            {
                this._ignoredMembers.Add(member);
            }
        }

        private void DisableComponentParentAutomapping(
            IModelInspector inspector, PropertyPath member, IComponentAttributesMapper customizer)
        {
            MemberInfo parentMapping = member.LocalMember.GetPropertyOrFieldType().GetFirstPropertyOfType(member.Owner());
            this.DisableAutomappingFor(parentMapping);

        }

        #endregion
    }

    public static class PropertyPathExtensions
    {
        #region Public Methods

        public static Type CollectionElementType(this PropertyPath member)
        {
            return member.LocalMember.GetPropertyOrFieldType().DetermineCollectionElementOrDictionaryValueType();
        }

        public static string ManyToManyIntermediateTableName(this PropertyPath member)
        {
            return String.Join(
                ModelMapperWithNamingConventions.ManyToManyIntermediateTableInfix,
                member.ManyToManySidesNames().OrderBy(x => x));
        }

        public static MemberInfo OneToManyOtherSideProperty(this PropertyPath member)
        {
            return member.CollectionElementType().GetFirstPropertyOfType(member.Owner());
        }

        public static Type Owner(this PropertyPath member)
        {
            return member.GetRootMember().DeclaringType;
        }

        #endregion

        #region Methods



        private static IEnumerable<string> ManyToManySidesNames(this PropertyPath member)
        {
            yield return member.Owner().Name;
            yield return member.CollectionElementType().Name;
        }

        #endregion
    }
}