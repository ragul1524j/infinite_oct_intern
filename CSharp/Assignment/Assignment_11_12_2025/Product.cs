using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_12_2025
{
    public class Product
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public int qty { get; set; }


        // 1. find second highest price

        public void SecondHighestSalary(List<Product> product)
        {
            var res = product.OrderByDescending(t => t.price).Skip(1).Take(1);
            foreach(var item in res)
            {
                Console.WriteLine($"{item.pname} \t\t {item.price}");
            }
        }

        // 2. display top 3 highest price
       
        public void Top3(List<Product> product)
        {
            var res = product.OrderByDescending(t => t.price).Take(3);

            foreach(var item in res)
            {
                Console.WriteLine($"{item.pname} \t\t {item.price}");
                
            }
;        }


        // 3. find the sum of price where product names contains letter 'O'

        public void SumOfProductsO(List<Product> product)
        {

            int res = product.Where(t => t.pname.Contains("o")).Sum(t => t.price);

            Console.WriteLine($"Sum of price where product names contains letter 'O' : {res}");
        }

        // 4. find the product name ends with e and display only pid and pname (filter by
        // column name)

        public void ProductNameEndWithe(List<Product> product)
        {
            var res = product.Where(t => t.pname.EndsWith("e"));
            foreach(var item in res)
            {
                Console.WriteLine($"{item.pid} \t\t {item.pname}");
            }
        }

        // 5. group all records by qty find max of price

        public void GroupRecord(List<Product> product)
        {
            var res = product.GroupBy(t => t.qty).Select(g => new
            { Qty = g.Key,
            MaxPrice = g.Max(x => x.price)});

            foreach(var item in res)
            {
                Console.WriteLine($"{item.Qty} \t {item.MaxPrice}");
            }

        }
    }
}
