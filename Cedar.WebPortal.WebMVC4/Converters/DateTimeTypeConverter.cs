namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;

    using AutoMapper;

    using Cedar.WebPortal.Common;

    public class DateTimeTypeConverter : ITypeConverter<string, DateTime?>,
                                         ITypeConverter<DateTime?, string>,
                                         ITypeConverter<string, DateTime>,
                                         ITypeConverter<DateTime, string>
    {
        #region Implemented Interfaces

        #region ITypeConverter<DateTime,string>

        string ITypeConverter<DateTime, string>.Convert(ResolutionContext context)
        {
            string strin = (this as ITypeConverter<DateTime?, string>).Convert(context);
            return strin;
        }

        #endregion

        #region ITypeConverter<DateTime?,string>

        string ITypeConverter<DateTime?, string>.Convert(ResolutionContext context)
        {
            return PersianCalendarHelper.ConvertToPersian(context.SourceValue);
        }

        #endregion

        #region ITypeConverter<string,DateTime?>

        DateTime? ITypeConverter<string, DateTime?>.Convert(ResolutionContext context)
        {
            return PersianCalendarHelper.ConvertToGeorgian(context.SourceValue);
        }

        #endregion

        #region ITypeConverter<string,DateTime>

        DateTime ITypeConverter<string, DateTime>.Convert(ResolutionContext context)
        {
            DateTime? dateTime = (this as ITypeConverter<string, DateTime?>).Convert(context);
            return dateTime.HasValue ? dateTime.Value : DateTime.MinValue;
        }

        #endregion

        #endregion
    }
}