using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3RideEasy
{
    internal class Vehicle
    {
        public string Vehicle_type;

        public int BaseFare;
        public int RatePerKm;

        public Vehicle(string type)
        {
            Vehicle_type = type;

            switch (Vehicle_type.ToLower())
            {
                case "hatchback":
                    BaseFare = 50;
                    RatePerKm = 10;
                    break;
                case "sedan":
                    BaseFare = 60;
                    RatePerKm = 20;
                    break;
                case "suv":
                    BaseFare = 70;
                    RatePerKm = 30;
                    break;
                default:
                    Console.WriteLine("Invalid Type");
                    break;

            }
        }

    }
}
