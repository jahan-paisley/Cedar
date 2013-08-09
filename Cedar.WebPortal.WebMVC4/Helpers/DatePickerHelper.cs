namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Web.Mvc;

    public static class DatePickerHelper
    {
        #region Public Methods

        public static string DatePicker(this HtmlHelper htmlHelper, string name, string value)
        {
            return "<script type=\"text/javascript\">" + "$(function() {" + "$(\"#" + name + "\").datepicker();" + "});" +
                   "</script>" + "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" +
                   name + "\"/>";
        }

        #endregion
    }
}