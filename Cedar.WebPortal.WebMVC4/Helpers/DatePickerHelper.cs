using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace Cedar.WebPortal.WebMVC4.Helpers
{
    public static class DatePickerHelper
    {
        public static string DatePicker(this HtmlHelper htmlHelper, string name, string value)
        {

            return "<script type=\"text/javascript\">" +
                     "$(function() {" +
                     "$(\"#" + name + "\").datepicker();" +
                     "});" +
                     "</script>" +
                     "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";

        }

    }
}