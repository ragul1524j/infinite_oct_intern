using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3RideEasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int distance;
            string type;
            Console.Write("Customer : ");
            name = Console.ReadLine();
            Console.Write("Distance : ");
            distance = Convert.ToInt16(Console.ReadLine());
            Console.Write("Vehicle : ");
            type = Console.ReadLine();
            Customer customer = new Customer(name,distance);
            Vehicle vehicle = new Vehicle(type);
            Pricing pricing = new Pricing();
            pricing.Subtotal(customer, vehicle);
            pricing.PrintDetails();
        }
    }
}
