using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Assignment
{
    internal class Calculation
    {


        public string Student_name;
        public int[] marks;

       

        public void Calculation_Perform(int[] arr,out int Total,out int average,out string Grade)
        {
            int total = 0;
            for(int i=0;i<arr.Length;i++)
            {
                total += arr[i];
            }
            Total =total;
            average = total / arr.Length;
            int mark = (int)(average);
            if(mark > 90)
            {
                Grade = "A+";
            }
            else if(mark >= 80 && mark <= 89)
            {
                Grade = "A";
            }
            else if(mark >= 70 && mark <= 79)
            {
                Grade = "B";
            }
            else if(mark >= 60 && mark <= 69)
            {
                Grade = "C";
            }
            else if(mark >= 50 && mark <= 59)
            {
                Grade = "D";
            }
            else
            {
                Grade = "F";
            }
        }

        public void PrintDetails(int total,int average,string gr) 
        {
            Console.WriteLine($"Name : {Student_name}\nTotal Marks : {total}\nAverage : {average}\nGrade : {gr}");
        }




    }
}
