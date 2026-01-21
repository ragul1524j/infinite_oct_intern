using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company_DBFirstModel_MVC_Client.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
    }
}