namespace Cedar.WebPortal.Common
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;

    public static class ObjectExtensions
    {
        #region Public Methods

        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return !IsNull(obj);
        }

        public static T Cast<T>(this object obj) where T : class
        {
            return obj as T;
        }

        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }

        public static string Item<TItem, TMember>(this TItem obj, Expression<Func<TItem, TMember>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return ((MemberExpression)(expression.Body)).Member.Name;
            }
            if (expression.Body is UnaryExpression)
            {
                return ((MemberExpression)((UnaryExpression)(expression.Body)).Operand).Member.Name;
            }
            if (expression.Body is ParameterExpression)
            {
                return expression.Body.Type.Name;
            }
            throw new InvalidOperationException();
        }

        public static string Item<TItem>(this TItem obj, Expression<Func<TItem>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return ((MemberExpression)(expression.Body)).Member.Name;
            }
            if (expression.Body is UnaryExpression)
            {
                return ((MemberExpression)((UnaryExpression)(expression.Body)).Operand).Member.Name;
            }
            if (expression.Body is ParameterExpression)
            {
                return expression.Body.Type.Name;
            }
            throw new InvalidOperationException();
        }

        public static void SetProperty<TEntity, TItem>(this TEntity objec, string name, TItem value)
        {
            typeof(TEntity).GetProperty(name).SetValue(objec, value, null);
        }
        public static TItem GetProperty<TEntity, TItem>(this TEntity objec, string name) where TEntity : class
        {
            if (objec != null)
            {
                var value = typeof(TEntity).GetProperty(name).GetValue(objec, null);
                if (value != null)
                {
                    return (TItem)(value);
                }
            }
            return default(TItem);
        }

        public static object GetProperty(this object objec, string name)
        {
            return objec.IsNotNull() ? objec.GetType().GetProperty(name).GetValue(objec, null) : null;
        }

        #endregion
    }
}