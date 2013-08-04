using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Cedar.WebPortal.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Type;
using Configuration = NHibernate.Cfg.Configuration;

namespace Cedar.WebPortal.Data
{
    /// <summary>
    ///     This is an example automapping configuration. You should create your own that either
    ///     implements IAutomappingConfiguration directly, or inherits from DefaultAutomappingConfiguration.
    ///     Overriding methods in this class will alter how the automapper behaves.
    /// </summary>
    public class MyAutoMapper : ConventionModelMapper
    {
        #region Constants and Fields

        private const string ComponentNamespace = "Cedar.WebPortal.Domain.Component";

        private const string DomainNamespace = "Cedar.WebPortal.Domain";

        #endregion

        #region Methods

        internal static ISessionFactory BuildSessionFactory()
        {
            var mapper = new MyAutoMapper();
            Type[] exportedTypes = typeof (Applicant).Assembly.GetExportedTypes();

            mapper.IsProperty(IsProperty);
            mapper.IsEntity(IsEntity);
            mapper.IsManyToMany(IsManyToMany);
            mapper.IsOneToMany(IsOneToMany);
            mapper.IsManyToOne(IsManyToOne);

            mapper.BeforeMapComponent += OnBeforeMapComponent;
            mapper.BeforeMapClass += OnBeforeMapClass;
            mapper.BeforeMapProperty += OnBeforeMapProperty;

            // mapper.BeforeMapManyToMany += ManyToManyConvention;

            //mapper.BeforeMapMapKeyManyToMany += MapMapKeyManyToMany;

            //mapper.BeforeMapMapKeyManyToMany += OnBeforeMapKeyManyToMany;

            mapper.BeforeMapManyToOne += OnBeforeMapManyToOne;
            mapper.BeforeMapOneToMany += OnBeforeMapOneToMany;
            mapper.BeforeMapMapKey += OnBeforeMapKey;

            mapper.AfterMapManyToOne += OnAfterMapManyToOne;
            // mapper.AfterMapManyToMany += OnAfterMapKeyManyToMany;
            mapper.AfterMapOneToMany += OnAfterMapOneToMany;


            mapper.AddMapping<LocationMapOverride>();
            mapper.AddMapping<NewsMappingOverride>();

            HbmMapping map = mapper.CompileMappingFor(exportedTypes);

            var configure = new Configuration();

            configure.DataBaseIntegration(x =>
                {
                    x.Dialect<MsSql2008Dialect>();
                    x.ConnectionString = ConfigurationManager.ConnectionStrings["CedarContext"].ToString();
                    x.SchemaAction = SchemaAutoAction.Update;
                });
            configure.AddDeserializedMapping(map, "CedarModel");
            return configure.BuildSessionFactory();
        }

        private static bool IsEntity(Type o, bool b)
        {
            return o.Namespace == DomainNamespace && !o.IsEnum;
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

        private static bool IsManyToOne(MemberInfo memberInfo, bool arg)
        {
            Type type = ((PropertyInfo) memberInfo).PropertyType;
            return type.Namespace == DomainNamespace && !type.IsGenericCollection();
        }

        private static bool IsOneToMany(MemberInfo memberInfo, bool arg)
        {
            if (IsManyToMany(memberInfo, arg))
                return false;

            Type propertyType = ((PropertyInfo) memberInfo).PropertyType;
            return propertyType.IsGenericCollection() &&
                   propertyType.GetGenericArguments().All(o => o.Namespace == DomainNamespace);
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

        private static bool IsManyCollection(PropertyInfo info)
        {
            return info.PropertyType.IsGenericCollection()
                   && !info.PropertyType.IsArray;
        }

        //TODO: it should run but now it's not
        private static void OnBeforeMapKeyManyToMany(IModelInspector modelInspector, PropertyPath member,
                                                     IMapKeyManyToManyMapper customizer)
        {
            customizer.ForeignKey(member.ToString());
            customizer.Column(member.ToString());
        }

        private static void OnBeforeMapClass(IModelInspector inspector, Type type, IClassAttributesMapper customizer)
        {
            customizer.Id(x => x.Generator(Generators.GuidComb));
            customizer.Id(x => x.Column(type.Name + "Id"));
        }

        //TODO: check whether it's running altogether or not
        private static void OnBeforeMapComponent(IModelInspector inspector, PropertyPath member,
                                                 IComponentAttributesMapper customizer)
        {
            member.ToColumnName(member.LocalMember.Name);
        }

        //TODO: justify the foreign key naming conventions
        private static void OnBeforeMapOneToMany(IModelInspector modelinspector, PropertyPath member,
                                                 IOneToManyMapper customizer)
        {
        }

        //TODO: justify the foreign key naming conventions
        private static void OnBeforeMapKey(IModelInspector modelinspector, PropertyPath member, IMapKeyMapper customizer)
        {
            customizer.Column("PK_" + member.LocalMember.DeclaringType.Name);
        }

        private static void OnBeforeMapManyToOne(IModelInspector inspector, PropertyPath member,
                                                 IManyToOneMapper customizer)
        {
            var info = (PropertyInfo) member.LocalMember;
            customizer.Column(info.Name + "_" + info.PropertyType.Name + "Id");
            customizer.ForeignKey("FK_" + info.DeclaringType.Name + "_" + info.Name);
            customizer.Cascade(Cascade.All);
        }

        //TODO: check some fields with large contents like News.Content
        private static void OnBeforeMapProperty(IModelInspector inspector, PropertyPath propertyPath,
                                                IPropertyMapper customizer)
        {
            var info = (PropertyInfo) propertyPath.LocalMember;

            if (propertyPath.LocalMember.DeclaringType != null &&
                inspector.IsComponent(propertyPath.LocalMember.DeclaringType))
            {
                customizer.Column(propertyPath.ToString().Replace(".", "_"));
                return;
            }
            if (info.PropertyType == typeof (byte[]))
            {
                customizer.Type(new BinaryBlobType());
                customizer.Length(Int32.MaxValue);
                return;
            }
            if (info.PropertyType.IsEnum)
            {
                Type makeGenericType = typeof (EnumStringType<>).MakeGenericType(info.PropertyType);
                object instance = Activator.CreateInstance(makeGenericType);
                customizer.Type((IType) instance);
                customizer.Column(info.Name);
                return;
            }
            if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof (Nullable<>)
                && info.PropertyType.GetGenericArguments()[0].IsEnum)
            {
                Type makeGenericType =
                    typeof (EnumStringType<>).MakeGenericType(info.PropertyType.GetGenericArguments()[0]);
                object parameters = Activator.CreateInstance(makeGenericType);
                customizer.Type((IType) parameters);
                customizer.Column(info.Name);
            }
        }

        private static void OnAfterMapManyToOne(IModelInspector modelInspector, PropertyPath member,
                                                IManyToOneMapper customizer)
        {
            var info = member.LocalMember as PropertyInfo;
            customizer.Column(info.Name + "_" + info.PropertyType.Name + "Id");
        }

        private static void OnAfterMapKeyManyToMany(IModelInspector modelinspector, PropertyPath member,
                                                    IManyToManyMapper customizer)
        {
            MemberInfo localMember = member.LocalMember;
            var propertyInfo = localMember as PropertyInfo;

            customizer.ForeignKey("FK_" + localMember.DeclaringType.Name + "_" + localMember.Name);
            customizer.Column(propertyInfo.PropertyType.GetGenericArguments()[0].Name + "_Id");
        }

        private static void OnAfterMapOneToMany(IModelInspector modelInspector, PropertyPath member,
                                                IOneToManyMapper customizer)
        {
        }

        public static void ManyToManyConvention(IModelInspector modelInspector, PropertyPath member,
                                                IManyToManyMapper map)
        {
            map.ForeignKey(
                string.Format("fk_{0}_{1}",
                              member.LocalMember.Name,
                              member.GetContainerEntity(modelInspector).Name));
        }

        public static void MapMapKeyManyToMany(IModelInspector modelInspector, PropertyPath member,
                                               IMapKeyManyToManyMapper map)
        {
        }

        #endregion
    }
}