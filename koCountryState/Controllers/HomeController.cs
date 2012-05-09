using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KoCountryState.Controllers
{
    // todo: way of C# to js mapping?

    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public string code { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
    }

    public class CountryAndState
    {
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
    }

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var countryList = new[]
                                  {
                                      new Country() {code = "CA", name = "Canada"},
                                      new Country() {code = "US", name = "United States"},
                                      new Country() {code = "UK", name = "United Kingdom"}
                                  };

            return View(countryList);
        }

        [HttpPost]
        public ActionResult SendSelection(CountryAndState result)
        {
            return Json(string.Format("Success. Selected country: {0}, state: {1}.", result.CountryCode, result.StateCode));
        }

        public ActionResult GetStates(string countryCode)
        {
            var statesList = new List<State>()
                                         {
                                             new State { code = "CA", countryCode = "NU", name = "Nunavut"},
                                             new State { code = "ON", countryCode = "CA", name = "Ontario"},
                                             new State { code = "QU", countryCode = "CA", name = "Quebec"},
                                             new State { code = "NS", countryCode = "CA", name = "Nova Scotia"},
                                             new State { code = "NB", countryCode = "CA", name = "New Brunswick"},
                                             new State { code = "MA", countryCode = "CA", name = "Manitoba"},
                                             new State { code = "BC", countryCode = "CA", name = "British Columbia"},
                                             new State { code = "PEI", countryCode = "CA", name = "Prince Edward Island"},
                                             new State { code = "SA", countryCode = "CA", name = "Saskatchewan" },
                                             new State { code = "AL", countryCode = "CA", name = "Alberta" },
                                             new State { code = "NL", countryCode = "CA", name = "Newfoundland and Labrador" },
                                             new State { code = "NY", countryCode = "US", name = "New-York" },
                                             new State { code = "CA", countryCode = "US", name = "California" },
                                             new State { code = "WA", countryCode = "US", name = "Washington" },
                                             new State { code = "VE", countryCode = "US", name = "Vermont" },
                                             new State { code = "BR", countryCode = "UK", name = "Britian" },
                                             new State { code = "NI", countryCode = "UK", name = "Northern Ireland" },
                                             new State { code = "SC", countryCode = "UK", name = "Scotland" },
                                             new State { code = "WA", countryCode = "UK", name = "Wales" }
                                         };

            return Json(statesList.Where(s => s.countryCode == countryCode), JsonRequestBehavior.AllowGet);
        }

    }
}
