using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company_DBFirstModel_MVC_Client.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
    }
}