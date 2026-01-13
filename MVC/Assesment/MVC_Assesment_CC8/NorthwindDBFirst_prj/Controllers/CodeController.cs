using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindDBFirst_prj.Models;

namespace NorthwindDBFirst_prj.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // returns all the customers in germany

        public ActionResult CustomersByCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return HttpNotFound();
            }
            var customers = db.Customers.Where(c => c.Country == country)
                              .ToList();

            return View(customers);
        }


        //returns customer details for OrderID = 1024

        public ActionResult CustomerByOrderId(int orderId)
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == orderId).Select(o => o.Customer)
                             .FirstOrDefault();

            return View(customer);
        }
    }
}