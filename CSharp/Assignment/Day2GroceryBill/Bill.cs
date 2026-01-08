using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2GroceryBill
{
    internal class Bill
    {
        public List<Item> List = new List<Item>();
        public void AddItem(Item item)
        {
            List.Add(item);
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach(Item item in List)
            {
                total += item.totalPrice;
            }
            return total;
        }

        public void ApplyDicount(double total,out double discount)
        {
            if(total > 1000)
            {
                discount = total * 0.10;
            }
            else
            {
                discount = 0;
            }
        }
        public void Display(double total,double discount)
        {

            Console.WriteLine("\n.......FinalBill......\n");
            Console.WriteLine("Item\tQty\tPrice\tTotal");
            foreach(Item item in List)
            {
                Console.WriteLine($"{item.name}\t{item.quantity}\t{item.pricePerUnit}\t{item.totalPrice}\n");
            }



            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Total:\t\t\t\t₹{total}");
            Console.WriteLine($"Discount:\t\t\t₹{discount}");
            Console.WriteLine($"Grand Total:\t\t\t₹{total - discount}");

        }
    }
}
