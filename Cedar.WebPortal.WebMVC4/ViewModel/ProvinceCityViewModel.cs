namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class ProvinceCityViewModel
    {
        #region Properties

        public int? Month { get; set; }

        public int? Year { get; set; }
     


//foreach (string name in q)
//    Console.WriteLine("Customer name = {0}", name);

//        XElement Element=new XElement(doc.Elements("Province"));

//        IEnumerable<string> partNos =
//    from doc in purchaseOrder.Descendants("Item")
//    select (string)item.Attribute("PartNumber");

        public IEnumerable<SelectListItem> Province
        {
            get
            {
      
                return
                    Enumerable.Range(2000, 12).Select(
                        x => new SelectListItem { Value = x.ToString(), Text = x.ToString() });
            }
        }

        #endregion
    }

    public class Province
    {
        #region Properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        #endregion
    }

    public class City
    {
        #region Properties

        public string CityName { get; set; }

        public Guid Id { get; set; }

        public Guid ProvinceId { get; set; }

        #endregion
    }
}