using Company_DBFirstModel_MVC_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Company_DBFirstModel_MVC_Client.Controllers
{
    public class OrdersController : Controller
    {

        private readonly string baseUrl = "https://localhost:44353/api/orders/";


        public ActionResult BuchananOrders()
        {
            IEnumerable<OrderViewModel> ordersList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var response = client.GetAsync("BuchananOrders");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var jsonData = result.Content.ReadAsStringAsync().Result;
                    ordersList = JsonConvert.DeserializeObject<List<OrderViewModel>>(jsonData);
                }
                else
                {
                    ordersList = Enumerable.Empty<OrderViewModel>();
                }
            }

            return View(ordersList);
        }

        

        
    }
}
