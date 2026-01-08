using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_12_2025
{
    public class Arrays
    {
        // Q1. Write a LINQ query to fetch unique values from listA.
        // Expected Output: 10, 20, 30, 40, 50

        public void DistinctElements(List<int> listA)
        {
            var res = listA.Distinct();
            Console.WriteLine("The Distinct Values");
            foreach (var x in res)
            {
                Console.WriteLine(x);
            }
        }

        // Q2. Combine values from listA and listB without duplicates.
        public void CombineList(List<int> listA, List<int> listB)
        {
            var res = listA.Concat(listB).Distinct();
            Console.WriteLine("Distinct Values from List A and ListB");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        //Q3. Find items common in listA and listB.

        public void CommonListElements(List<int> listA, List<int> listB)
        {
            var res = from x in listA
                      from y in listB
                      where x == y
                      select x;
            var answer = res.Distinct();
            Console.WriteLine("Common Elements in Both List");
            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }

        // Q4. Find names present in names1 but not in names2.
        public void CommonNames(List<string> names1, List<string> names2)
        {
            var res = from n1 in names1
                      from n2 in names2
                      where n1 == n2
                      select n1;

            var answer = res.Distinct();

            Console.WriteLine("Common Names in Both Lists");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        // Q5. Find sum of price of all products.

        public void SumOfPrice(List<Product> product)
        {
            var res = product.Sum(p => p.price);
            Console.WriteLine("Sum of All Products : " + res);
        }

        // Q6. Find count of products where price > 5000. 
        public void ProductGreaterThan5000(List<Product> product)
        {
            int res = product.Count(p => p.price > 5000);
            Console.WriteLine($"count of products where price > 5000 : {res}");
        }

        // Q7. Find the highest value in listA.

        public void HighestValueOfList(List<int> listA)
        {
            var res = listA.Max();

            Console.WriteLine($"The highest value in listA : {res}");
        }

        /* Q8. Write a LINQ query to find numbers divisible by 3 
int [] numbers = { 1, 4, 9, 16, 25, 36 }; */

        public void NumberDivideBY3()
        {
            int[] numbers = { 1, 4, 9, 16, 25, 36 };
            var res = numbers.Where(t => t % 3 == 0);
            Console.WriteLine("Numbers Diisible by 3\n");
            foreach(var item in res)
            {
                Console.Write($"{item} ");
            }
        }

        /* Write a Linq to query to sort based on string Length 
string[] st = { "India", "Srilanka", "canada", "Singapore" }; */

        public void SortByStringLength()
        {
            string[] st = { "India", "Srilanka", "canada", "Singapore" };

            var res = from t in st
                      orderby t.Length ascending
                      select t;
            Console.WriteLine("String sort by lenght");
            foreach(var item in res)
            {
                Console.WriteLine(item);
            }
        }




    }
}
