namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.IO;
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        #region Public Methods

        public static HtmlHelper HtmlHelper(ControllerContext context)
        {
            var htmlHelper =
                new HtmlHelper(
                    new ViewContext(
                        context,
                        new WebFormView(context, "HACK"),
                        new ViewDataDictionary(),
                        new TempDataDictionary(),
                        new StringWriter()),
                    new ViewPage());
            return htmlHelper;
        }

        #endregion
    }
}