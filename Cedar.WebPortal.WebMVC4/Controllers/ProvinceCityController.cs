using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cedar.WebPortal.WebMVC4.Controllers
{
    using Cedar.WebPortal.WebMVC4.ViewModel;

    public class ProvinceCityController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProvinceCityViewModel();
            return View(model);
        }

        public ActionResult Months(int year)
        {
            if (year == 2011)
            {
                return Json(
                    Enumerable.Range(1, 3).Select(x => new { value = x, text = x }),
                    JsonRequestBehavior.AllowGet
                );
            }
            return Json(
                Enumerable.Range(1, 12).Select(x => new { value = x, text = x }),
                JsonRequestBehavior.AllowGet
            );
        }

    }
}
