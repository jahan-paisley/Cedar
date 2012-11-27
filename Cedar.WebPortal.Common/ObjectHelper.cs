using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cedar.WebPortal.Common
{
    public static class  ObjectHelper
    {
        public static Dictionary<string, object> Dump(object obj)
        {
            var result = new Dictionary<string, object>();
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object propertyValue = obj.GetProperty(propertyInfo.Name);

                if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) &&
                    propertyInfo.PropertyType.IsGenericType)
                {
                    var enumerable = propertyValue as IEnumerable<Object>;
                    if (enumerable != null)
                    {
                        List<object> objects = enumerable.ToList();
                        for (int i = 0; i < objects.Count; i++)
                        {
                            result.Add(propertyInfo.Name + i, ObjectHelper.Dump(objects[i]));
                        }
                    }
                }
                else
                {
                    object value = propertyInfo.GetValue(obj, null);
                    if (typeof(Nullable<>).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        string colName = propertyInfo.Name;
                        result.Add(colName, value.IsNull() ? null : value);
                    }
                    else if (propertyInfo.PropertyType.IsEnum)
                    {
                        string colName = propertyInfo.Name;
                        result.Add(colName, value.IsNull() ? null : value);
                    }
                    else if (propertyInfo.PropertyType.FullName.Contains("Cedar") &&
                           !propertyInfo.PropertyType.FullName.Contains("Attachment"))
                    {
                        //exclude circular references 
                        //propertyType is Distributor for example
                        //so in properties of Distributor, we shoudln't find the declaring type(type that contains this property)
                        Type propertyType = propertyInfo.PropertyType;
                        if (
                            !propertyType.GetProperties().Any(
                                o =>
                                o.PropertyType == propertyInfo.DeclaringType ||
                                (o.PropertyType.IsGenericType &&
                                 o.PropertyType.GetGenericArguments().Contains(propertyInfo.DeclaringType))))
                        {
                            foreach (var o in ObjectHelper.Dump(propertyValue))
                            {
                                result.Add(propertyInfo.Name + "_" + o.Key, o.Value);
                            }
                            //result.Add(propertyInfo.Name, this.Dump(propertyValue));
                        }
                    }
                    else if (!propertyInfo.PropertyType.FullName.Contains("Attachment"))
                    {
                        string colName = propertyInfo.Name;
                        result.Add(colName, value.IsNull() ? null : value);
                    }
                }

            }
            return result;
        }
    }
}
