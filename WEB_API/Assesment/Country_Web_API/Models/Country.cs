using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Country_Web_API.Models
{
    public class Country
    {
        public int ID { get; set; }

        public string CountryName { get; set; }

        public string Capital { get; set; }
    }
}