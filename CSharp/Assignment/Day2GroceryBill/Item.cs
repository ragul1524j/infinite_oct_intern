using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2GroceryBill
{
    internal class Item
    {
        public string name;
        public int quantity;
        public int pricePerUnit;
        public int totalPrice;


        public Item(string name,int quantity,int price)
        {
            this.name = name;
            this.quantity = quantity;
            pricePerUnit = price;
            totalPrice = price * quantity;
        }
    }
}
