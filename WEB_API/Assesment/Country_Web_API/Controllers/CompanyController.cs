using Country_Web_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Country_Web_API.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countries = new List<Country>()
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington DC" }
        };

        [ActionName("GetAllCountries")]
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        [ActionName("GetCountryById")]
        public IHttpActionResult Get(int id)
        {
            var country = countries.SingleOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }


        public HttpResponseMessage Post([FromBody] Country country)
        {
            country.ID = countries.Count > 0
                ? countries.Max(c => c.ID) + 1
                : 1;

            countries.Add(country);

            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }


        public HttpResponseMessage Put(int id, [FromUri] string countryName, string capital)
        {
            var existingCountry = countries.SingleOrDefault(c => c.ID == id);

            if (existingCountry == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            existingCountry.CountryName = countryName;
            existingCountry.Capital = capital;

            return Request.CreateResponse(HttpStatusCode.OK, existingCountry);
        }

        public HttpResponseMessage Delete(int id)
        {
            var country = countries.SingleOrDefault(c => c.ID == id);

            if (country == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            countries.Remove(country);

            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }
    }
}
