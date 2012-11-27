using System;
using System.Collections.Specialized;
using AutoMapper;

namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Web.Mvc;

    using Cedar.WebPortal.WebMVC4.Models;

    public class ProfileBinder : IModelBinder
    {
        //public object BindModel(ControllerContext controllerContext,
        //    ModelBindingContext bindingContext)
        //{
        //    var form = controllerContext.HttpContext.Request.Form;
        //    var profile = ((UserProfile)(controllerContext.HttpContext.Profile));
        //    profile.Address = form["Address"];
        //    profile.City = form["City"];
        //    profile.FirstName = form["FirstName"];
        //    profile.LastName = form["LastName"];
        //    profile.MSISDN = form["MSISDN"];
        //    profile.MobileNo = form["MobileNo"];
        //    long retval;
        //    if (Int64.TryParse(form["NationalNo"], out retval))
        //    {
        //        profile.NationalNo = retval;
        //    }
        //    profile.Province = form["Province"];
        //    profile.TelNo = form["TelNo"];
        //    return controllerContext.HttpContext.Profile;
        //}
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }

}