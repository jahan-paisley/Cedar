using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Cedar.WebPortal.Domain;

    public class LocationCollectionBinder : IModelBinder
    {
        #region Constants and Fields

        private readonly string arg;

        #endregion

        #region Constructors and Destructors

        public LocationCollectionBinder(string arg)
        {
            this.arg = arg;
        }

        #endregion

        #region Implemented Interfaces

        #region IModelBinder

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (this.arg == "Locations")
            {
                var locationSpliterStrings = controllerContext.HttpContext.Request.Form[this.arg].Split(',');
                return
                    locationSpliterStrings.Select(
                        locationIdSpilted => new Location { LocationId = Guid.Parse(locationIdSpilted)}).ToList();
            }
            //if (this.arg == "ApplicantSalesShopOffices")
            //{
            //    var keysCollection = controllerContext.HttpContext.Request.Form.Keys;
            //    foreach (string key in keysCollection)
            //    {
            //        if (key.Contains("].Location"))
            //        {
            //            return controllerContext.HttpContext.Request.Form[key];
            //        }
            //    }

            //}
            return null;
        }

        #endregion

        #endregion
    }
}