namespace Cedar.WebPortal.WebMVC4.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Cedar.WebPortal.Domain;
    using Cedar.WebPortal.Service.Common;

    public class ControllerHelper
    {
        #region Public Methods

        public static void GetLocationSelectedListItem(
            IList<Location> locations, out MultiSelectList allLocation, out List<SelectListItem> selectListItems)
        {
            var multiSelectList = new MultiSelectList(locations, "LocationId", "Province", locations);
            allLocation = multiSelectList;
            selectListItems =
                locations.Select(o => new SelectListItem { Text = o.Province, Value = o.Province }).ToList();
        }

        public static List<Location> GetLocations(ILocationService locationService)
        {
            return locationService.GetAll().OrderBy(o => o.Province).ToList();
        }

        #endregion
    }
}