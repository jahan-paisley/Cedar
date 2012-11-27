//namespace Cedar.WebPortal.Data
//{
//    using System;

//    using FluentNHibernate.Conventions;
//    using FluentNHibernate.Conventions.Instances;

//    using NHibernate.Type;

//    internal class Conventions : IReferenceConvention,
//                                 IHasManyConvention,
//                                 IHasManyToManyConvention,
//                                 IIdConvention,
//                                 IComponentConvention,
//                                 IPropertyConvention,
//                                 IHasOneConvention
//    {
//        #region Constants and Fields

//        private const string Id = "Id";

//        #endregion

//        #region Implemented Interfaces

//        #region IConvention<IComponentInspector,IComponentInstance>

//        public void Apply(IComponentInstance instance)
//        {
////            foreach (IPropertyInstance propertyInstance in instance.Properties)
////            {
////                propertyInstance.Column(instance.Property.Name + "_" + propertyInstance.Property.Name);
////            }
////            if (instance.EntityType.IsEnum)
////            {
////            }
//        }

//        #endregion

//        #region IConvention<IIdentityInspector,IIdentityInstance>

//        public void Apply(IIdentityInstance instance)
//        {
//            instance.Column(instance.EntityType.Name + Id);
//        }

//        #endregion

//        #region IConvention<IManyToManyCollectionInspector,IManyToManyCollectionInstance>

//        public void Apply(IManyToManyCollectionInstance instance)
//        {
//            //TODO: should be corrected for uni directional relations
//            if (instance.OtherSide == null)
//            {
                
//            }
//            instance.Cascade.All();
//        }

//        #endregion

//        #region IConvention<IManyToOneInspector,IManyToOneInstance>

//        public void Apply(IManyToOneInstance instance)
//        {
//            instance.Column(instance.Name + "_" + instance.Class.Name + Id);
//            instance.Cascade.All();
//        }

//        #endregion

//        #region IConvention<IOneToManyCollectionInspector,IOneToManyCollectionInstance>

//        public void Apply(IOneToManyCollectionInstance instance)
//        {
//            var columnName = instance.EntityType.Name + "_" + instance.EntityType.Name + Id;
//            instance.Key.Column(columnName);
//            instance.Cascade.All();
//            instance.Inverse();
//        }

//        #endregion

//        #region IConvention<IOneToOneInspector,IOneToOneInstance>

//        public void Apply(IOneToOneInstance instance)
//        {
//            instance.ForeignKey(instance.Name + "_" + instance.EntityType.Name + Id);
//        }

//        #endregion

//        #region IConvention<IPropertyInspector,IPropertyInstance>

//        public void Apply(IPropertyInstance instance)
//        {
//            if (instance.Property.PropertyType == typeof(byte[]))
//            {
//                instance.Length(Int32.MaxValue);
////                instance.CustomSqlType("VARBINARY(" + "MAX" /*Int16.MaxValue * 100*/ + ")");
//                //instance.Length(Int32.MaxValue);
//            }
//            if (instance.Property.PropertyType.IsEnum ||
//                (instance.Property.PropertyType.IsGenericType &&
//                 instance.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
//                 instance.Property.PropertyType.GetGenericArguments()[0].IsEnum))
//            {
//                instance.CustomType(instance.Property.PropertyType);
//            }
//        }

//        #endregion

//        #endregion
//    }
//}