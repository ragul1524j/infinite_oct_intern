using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4UtilityBillSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Welcome to Online Utility Billing System");
            Console.Write("Enter number of customers : ");
            n = Convert.ToInt16(Console.ReadLine());
            int i = 0;
            while (n != 0)
            {
                i++;
                Console.Write("\n\n");
                Console.WriteLine($"Enter details for Customer #{i}");
                int id;
                string name;
                int rate;
                Console.Write("Customer Id : ");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Customer Name : ");
                name = Console.ReadLine();
                Console.Write("Enter the rate per kWh : ");
                rate = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter monthly usage readings (in units) : ");
                string input = Console.ReadLine();
                string[] tokens = input.Split(' ');
                int[] arr = new int[tokens.Length];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = Convert.ToInt32(tokens[j]);
                }

                Customer customer = new Customer(id, name);
                customer.TotalUsage(arr);
                double total, netpayable, tax;
                customer.CalculateBill(out total, out netpayable, out tax);
                customer.PrintInvoice(total, netpayable, tax);
                n--;
            }
            Console.WriteLine("Utility Bill");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

        }
    }
}