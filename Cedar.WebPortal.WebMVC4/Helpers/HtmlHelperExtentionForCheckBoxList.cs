namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class HtmlHelperExtentionForCheckBoxList
    {
        #region Public Methods

        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo)
        {
            return htmlHelper.CheckBoxList(name, listInfo, (null));
        }

        public static string CheckBoxList(
            this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo, object htmlAttributes)
        {
            return htmlHelper.CheckBoxList(
                name, listInfo, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
        }

        public static string CheckBoxList(
            this HtmlHelper htmlHelper,
            string name,
            List<CheckBoxListInfo> listInfo,
            IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The argument must have a value", "name");
            }

            if (listInfo == null)
            {
                throw new ArgumentNullException("listInfo");
            }

            if (listInfo.Count < 1)
            {
                throw new ArgumentException("The list must contain at least one value", "listInfo");
            }

            var sb = new StringBuilder();

            foreach (CheckBoxListInfo info in listInfo)
            {
                var builder = new TagBuilder("input");

                if (info.IsChecked)
                {
                    builder.MergeAttribute("checked", "checked");
                }

                builder.MergeAttributes(htmlAttributes);

                builder.MergeAttribute("type", "checkbox");

                builder.MergeAttribute("value", info.Value.ToString());

                builder.MergeAttribute("name", name);

                builder.InnerHtml = info.DisplayText;

                sb.Append(builder.ToString(TagRenderMode.Normal));

                sb.Append("<br />");
            }

            return sb.ToString();
        }

        #endregion
    }

    public class CheckBoxListInfo
    {
        #region Constructors and Destructors

        public CheckBoxListInfo(Guid value, string displayText, bool isChecked)
        {
            this.Value = value;

            this.DisplayText = displayText;

            this.IsChecked = isChecked;
        }

        #endregion

        #region Properties

        public string DisplayText { get; private set; }

        public bool IsChecked { get; private set; }

        public Guid Value { get; private set; }

        #endregion
    }
}