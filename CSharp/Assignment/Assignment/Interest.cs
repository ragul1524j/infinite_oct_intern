using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Interest
    {
        public int principal_amount;
        public float rate;
        public int n;
        public int time;

        
        public void Calculate_Interest(int principal_amount,float rate)
        {
            int interests = (int)(principal_amount * rate * 1) / 100;
            Console.WriteLine("\n============ Simple Interest Calculation =============");
            Console.WriteLine($"The Simple Calculated for One Year of amount {principal_amount} is : {interests}");

        }

        public void Calculate_Interest(int principal_amount,float rate,int time)
        {
            int interest = (int)(principal_amount * rate * time) / 100;
            Console.WriteLine("\n============ Simple Interest Calculation =============");
            Console.WriteLine($"The Simple Calculated for {time}Years  of amount {principal_amount} is : {interest}");
        }


        public void Calculate_Interest(int principal_amount,float rate,int time,int n)
        {

            Console.WriteLine("\n============ Compound Interest Calculation =============");
            double amounts = principal_amount * Math.Pow((1 + rate / (100 * n)), n * time);
            double compound_interest = amounts - principal_amount;
            Console.WriteLine($"The Compnd Calculated for {time} Years of amount {principal_amount} is : {compound_interest}");

        }


    }
}
