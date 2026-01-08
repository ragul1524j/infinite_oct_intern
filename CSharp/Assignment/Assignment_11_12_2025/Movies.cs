using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_12_2025
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set; }
        public string Actress { get; set; }
        public int YOR { get; set; }


        // 1. display list of movienames acted by prabhas

        public void MoviePrabhas(List<Movies> li)
        {

            var res = from t in li  where t.Actor == "Prabhas" select t;

            foreach(var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }

        // 2. display list of all movies released in year 2019

        public void Movie2019(List<Movies> li)
        {
            var res = li.Where(t => t.YOR == 2019);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }

            Console.WriteLine("\n=======================================\n");
        }


        // 3. display the list of movies who acted together by prabhas and anushka

        public void MoviePrabhasAnuskha(List<Movies> li)
        {
            var res = li.Where(t => t.Actor == "Prabhas" && t.Actress == "Anushka");

            foreach(var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }
            Console.WriteLine("\n=======================================\n");

        }

        // 4. display the list of all actress who acted with prabhas //

        public void MovieActress(List<Movies> li)
        {
            var res = li.Where(t => t.Actor == "Prabhas");
            foreach(var item in res)
            {
                Console.WriteLine($"{item.Actress}");
            }
        }

        // 5. display the list of all moves released from 2010 - 2018

        public void MoviesBetween20102018(List<Movies> li)
        {
            var res = from t in li where t.YOR >= 2010 && t.YOR <= 2018 select t;

            foreach(var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }
        }

        // 6. sort YOR in descending order and display all its records

        public void SortByYOR(List<Movies> li)
        {
            var res = from t in li orderby t.YOR descending select t;
            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName} \t \t {item.YOR}");
            }
        }

        // 7. display max movies acted by each actor

        public void MaxMovies(List<Movies> li)
        {
            var res = from t in li
                      group t by t.Actor into grp
                      select new {
                          Actor = grp.Key,
                          TotalMovies = grp.Count()
                      };

            foreach(var item in res)
            {
                Console.WriteLine($"{item.Actor}\t\t{item.TotalMovies}");
            }

        }

        // 8. display the name of all movies which is 5 characters long

        public void MovieLength(List<Movies> li)
        {
            var res = li.Where(t => t.MovieName.Length == 5);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}");
            }
        }

        // 9.display names of actor and actress where movie released in
        // year 2017, 2009 and 2019 

        public void MovieNameOnYear(List<Movies> li)
        {
           

            var res = li.Where(t => t.YOR == 2009 || t.YOR ==2019 || t.YOR ==2017) ;

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}\t\t{item.YOR}");
            }
        }

        // 10.display the name of movies which start with 'b' and ends with 'i'

        public void MovieStartWithbEndWithi(List<Movies> li)
        {
            var res = li.Where(t => t.MovieName.StartsWith("B") && t.MovieName.EndsWith("i"));

            foreach (var item in res)
            {
                Console.WriteLine($"{item.MovieName}\t\t{item.YOR}");
            }
        }

        // 11.display name of actress who not acted with Rajini and print in descending order

        public void Rajini(List<Movies> li)
        {
            var actedWithRajini = li
                          .Where(t => t.Actor == "Rajini")
                          .Select(t => t.Actress)
                          .Distinct();

            var res = li
            .Where(t => !actedWithRajini.Contains(t.Actress))
            .Select(t => t.Actress)
            .Distinct()
            .OrderByDescending(a => a);

            foreach(var item in res)
            {
                Console.WriteLine($"{item}");
            }
        }

        /* 12. display records in following format
eg:
movie name cast
Bahubali prabhas-tammanna */

        public void DisplayMovieCast(List<Movies> li)
        {
            var res = from t in li select new { Movie = t.MovieName, Cast = t.Actor + "-" + t.Actress };
            foreach(var item in res)
            {
                Console.WriteLine($"{item.Movie} \t\t {item.Cast}");
            }
        }
        
    }
}
