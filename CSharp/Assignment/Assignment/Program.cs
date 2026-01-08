using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the choice : ");
            string choice;
            choice = Console.ReadLine();
            if (choice == "Interest")
            {

                int principal_amount;
                float rate;
                int n;
                int time;
                Console.Write("\n============= Enter the Details  =============\n");
                Console.Write("\nEnter Principal_Amount : ");
                principal_amount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Rate_Of_Interest : ");
                rate = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter N : ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Time_Period : ");
                time = Convert.ToInt32(Console.ReadLine());
                Interest interest = new Interest();

                interest.Calculate_Interest(principal_amount, rate);
                interest.Calculate_Interest(principal_amount, rate, time);
                interest.Calculate_Interest(principal_amount, rate, time, n);
            }
            else
            {
                Console.Write("============ Enter the details ============");
                int price, quantity;
                string coupn;
                Console.Write("\nEnter the price : ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the quatity : ");
                quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Coupn : ");
                coupn = Console.ReadLine();
                OnlineStore onlineStore = new OnlineStore();
                onlineStore.CheckOut(price);
                onlineStore.CheckOut(price,quantity);
                onlineStore.CheckOut(coupn);
                onlineStore.CheckOut(price,quantity, coupn);
            }
        }
    }
}
