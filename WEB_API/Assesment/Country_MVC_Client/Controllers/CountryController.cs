using Country_MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Country_MVC_Client.Controllers
{
    public class CountryController : Controller
    {
        private readonly string baseUrl = "https://localhost:44354/api/";

  
        public ActionResult Index()
        {
            IEnumerable<Country> countryList = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                var response = webclient.GetAsync("country").Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    countryList = JsonConvert.DeserializeObject<List<Country>>(data);
                }
                else
                {
                    countryList = Enumerable.Empty<Country>();
                }
            }
            return View(countryList);
        }

    
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                var response = webclient.PostAsJsonAsync("country", country).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Insertion failed");
            return View(country);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Country country = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                var response = webclient.GetAsync("country/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    country = JsonConvert.DeserializeObject<Country>(data);
                }
            }

            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                var response = webclient.PutAsJsonAsync(
                    "country?id=" + country.ID +
                    "&countryName=" + country.CountryName +
                    "&capital=" + country.Capital,
                    country
                ).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View(country);
        }

    
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Country country = null;

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                var response = webclient.GetAsync("country/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    country = JsonConvert.DeserializeObject<Country>(data);
                }
            }

            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Country country)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(baseUrl);
                webclient.DeleteAsync("country/" + country.ID).Wait();
            }

            return RedirectToAction("Index");
        }
    }
}
