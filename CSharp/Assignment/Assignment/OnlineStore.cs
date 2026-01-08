using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class OnlineStore
    {
        public void CheckOut(int price)
        {
            Console.WriteLine($"The Customer Buyed Grocery for Rs : {price}");
        }

        public void CheckOut(int price,int quantity)
        {
            int amount = price * quantity;
            Console.WriteLine($"The Customer Purchased {quantity} for Rs : {amount}");
        }

        public void CheckOut(String Coupn)
        {
            Console.WriteLine($"The Customer Used the Coupon {Coupn} To Purchase");
        }

        public void CheckOut(int price,int quantity,string Coupn)
        {
            int amount = price * quantity;
            int final_amount = amount - (int)(amount * 0.10);
            Console.WriteLine($"The Customer Purhased {quantity} items for Rs : {final_amount} with discount of 10 % ");
        }
    }
}
