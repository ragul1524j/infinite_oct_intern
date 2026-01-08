using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3RideEasy
{
    internal class Customer
    {
        public string Name;
        //public long Mobile_num;
        //public int Loyality_points;
        public int distance;

        public Customer(string name,int dist)
        {
            Name = name;
            //Mobile_num = num;
            //Loyality_points = point;
            distance = dist;
        }
    }
}
