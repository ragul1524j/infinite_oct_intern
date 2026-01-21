using Company_DBFirstModel_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Company_DBFirstModel_WebAPI.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        CompanyDBEntities db = new CompanyDBEntities();

        [HttpGet]
        [Route("BuchananOrders")]
        public HttpResponseMessage GetOrdersOfBuchananSteven()
        {
            var ordersList = db.Orders
                .Where(o => o.EmployeeID == 5)
                .Select(o => new
                {  o.OrderID,o.OrderDate, o.EmployeeID
                })
                .ToList();

            if (ordersList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ordersList);
        }




        [HttpGet]
        [Route("CustomersByCountry")]
        public HttpResponseMessage GetCustomersByCountry(string country)
        {
            var customers =
                db.GetCustomersByCountry(country).ToList();

            if (customers.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }
    }
}
