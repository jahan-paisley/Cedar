namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Web.Mvc;


    using Cedar.WebPortal.Common;

    public class DateTimeModelBinder : IModelBinder
    {
        #region Implemented Interfaces

        #region IModelBinder

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return  PersianCalendarUtility.ConvertToGeorgian(controllerContext.HttpContext.Request.Form[bindingContext.ModelName]);
        }

        #endregion

        #endregion
    }
}