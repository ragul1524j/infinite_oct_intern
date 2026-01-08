using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter number of students:");
            n = Convert.ToInt16(Console.ReadLine());
            while(n != 0)
            {


                Calculation calculator = new Calculation();
                Console.Write("Enter Student Name : ");
                calculator.Student_name = Console.ReadLine();
                calculator.marks = new int[3];
                for(int i=0;i<3;i++)
                {
                    Console.Write($"Enter marks for Subject {i + 1} : ");
                    calculator.marks[i] = Convert.ToInt16(Console.ReadLine());
                }

                int total_marks, average_marks;
                string grade;
                calculator.Calculation_Perform(calculator.marks, out total_marks, out average_marks, out grade);
                calculator.PrintDetails(total_marks, average_marks, grade);

                n--;
            }
        }
    }
}
