namespace Cedar.WebPortal.Common
{
    using System;
    using System.Linq.Expressions;

    public static class EnumHelper
    {
        #region Public Methods

        public static T GetValue<T>(string stringValue) where T : struct
        {
            T result;
            Enum.TryParse(stringValue, true, out result);
            return result;
        }

        #endregion
    }
}