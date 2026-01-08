using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_12_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movies> li = new List<Movies>()
    {
        new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas",
Actress="Tamanna", YOR=2015 },
        new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas",
Actress="Anushka", YOR=2017 },
        new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini",
Actress="Aish", YOR=2010 },
        new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir",
Actress="kareena", YOR=2009 },
        new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas",
Actress="shraddha", YOR=2019 },
    };



            List<Product> product = new List<Product>()
 {
 new Product() { pid = 100, pname = "book", price = 1000, qty = 5 },
 new Product() { pid = 200, pname = "cd", price = 2000, qty = 6 },
 new Product() { pid = 300, pname = "toys", price = 3000, qty = 5 },
 new Product() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
 new Product() { pid = 600, pname = "pen", price = 200, qty = 7 },
 new Product() { pid = 700, pname = "tv", price = 30000, qty = 7 },
 };





            Movies movie = new Movies();
            //movie.MoviePrabhas(li);
            //movie.Movie2019(li);
            //movie.MoviePrabhasAnuskha(li);
            //movie.MovieActress(li);
            //movie.MoviesBetween20102018(li);
            //movie.SortByYOR(li);
            //movie.MaxMovies(li);
            //movie.MovieLength(li);
            //movie.MovieNameOnYear(li);
            //movie.MovieStartWithbEndWithi(li);
            //movie.Rajini(li);
            //movie.DisplayMovieCast(li);


            Product products= new Product();
            //products.SecondHighestSalary(product);
            //products.Top3(product);
            //products.SumOfProductsO(product);
            //products.ProductNameEndWithe(product);
            //products.GroupRecord(product);






            List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
            List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };
            List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran",
"Kiran" };
            List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"
};



            Arrays array = new Arrays();
            //array.DistinctElements(listA);
            //array.CombineList(listA, listB);
            //array.CommonListElements(listA, listB);
            //array.CommonNames(names1, names2);
            //array.SumOfPrice(product);
            //array.ProductGreaterThan5000(product);
            //array.ProductGreaterThan5000(product);
            //array.HighestValueOfList(listA);
            //array.NumberDivideBY3();
            array.SortByStringLength();

        }
    }
}
