using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3RideEasy
{
    internal class Pricing
    {
        public int Gst;
        public int GrandTotal;
        public int Total;
        public int Subtotal(Customer customer,Vehicle vehicle)
        {
            Total = vehicle.BaseFare + (customer.distance * vehicle.RatePerKm);

            Gst = (int)(Total * 0.18);
            GrandTotal = Total + Gst;
            return Total;
        }

        public void PrintDetails()
        {
            Console.WriteLine("\n______________________________\n");
            Console.WriteLine($"Subtotal : {Total}\nGST (18%) : {Gst}\nFinalTotal : {GrandTotal}");
        }


        
    }
}
