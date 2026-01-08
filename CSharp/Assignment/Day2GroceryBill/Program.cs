using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2GroceryBill
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Bill bill = new Bill();
            while (true)
            {

                Console.Write("Enter item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter price per unit: ");
                int price = Convert.ToInt16(Console.ReadLine());

                Item item = new Item(name, quantity, price);
                bill.AddItem(item);

                Console.Write("Do you want to add another item? (yes/no): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n");
                }
            }
            // Calculate total and apply discount
            double total = bill.CalculateTotal();
            double discount;
            bill.ApplyDicount(total, out discount);

            // Display the final bill
            bill.Display(total, discount);


        }
    }
}
