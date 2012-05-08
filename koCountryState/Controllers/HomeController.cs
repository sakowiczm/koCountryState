using System.Web.Mvc;

namespace KoCountryState.Controllers
{
    // C# to js mapping

    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
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

        // todo: get lists from the server

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

    }
}
