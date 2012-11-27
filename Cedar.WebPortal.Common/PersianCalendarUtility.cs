namespace Cedar.WebPortal.Common
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class PersianCalendarUtility
    {
        public const string PersianDateRegex = @"(?:1[23]\d{2})\/(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|[12][0-9]|3[01])$";

        public static string ConvertToPersian(object obj)
        {
            if (obj.IsNull())
            {
                return null;
            }
            DateTime enDate;
            if (DateTime.TryParse(obj.ToString(), out enDate))
            {
                var calendar = new PersianCalendar();
                int year = calendar.GetYear(enDate);
                int month = calendar.GetMonth(enDate);
                int day = calendar.GetDayOfMonth(enDate);
                return String.Format("{0}/{1}/{2}", year, month, day);
            }
            else
            {
                return null;
            }
        }

        public static DateTime? ConvertToGeorgian(object obj)
        {
            if (obj.IsNull())
            {
                return null;
            }

            string farsiDate = obj.ToString();
            if (Regex.IsMatch(farsiDate, PersianDateRegex))
            {
                string[] split = farsiDate.Split('/');
                int year = Int32.Parse(split[0]);
                int month = Int32.Parse(split[1]);
                int day = Int32.Parse(split[2]);
                var calendar = new PersianCalendar();
                return calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            else
            {
                return null;
            }
        }
    }
}