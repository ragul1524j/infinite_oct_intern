using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8_12_2025_ADOnet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task obj = new Task();
            //Console.WriteLine("Task 1");
            //DateTime d1, d2;
            //Console.Write("Enter the d1 : ");
            //d1 = Convert.ToDateTime(Console.ReadLine());
            //Console.Write("Enter the d2 : ");
            //d2 = Convert.ToDateTime(Console.ReadLine());
            //obj.GetTransaction(d1, d2);

            //int deptid;
            //Console.WriteLine("Task 2");
            //Console.Write("Enter the Deptid : ");
            //deptid = Convert.ToInt32(Console.ReadLine());
            //obj.GetCommonRecords(deptid);

            //obj.InsertRecordsusingtrans();
            //obj.ScopeQuery();
            //obj.DoubleRead();
            //Console.ReadLine();




            int choice = 0;

            do
            {
                Console.WriteLine("\n========= ADO.NET ASSIGNMENT MENU =========");
                Console.WriteLine("1. Get Employees Between Dates (Stored Procedure)");
                Console.WriteLine("2. Get Common Records (Employee + Department)");
                Console.WriteLine("3. Insert Records using Transaction");
                Console.WriteLine("4. Insert + Fetch Identity using ScopeIdentity()");
                Console.WriteLine("5. Multi-Result Reader (Employee + Department)");
                Console.WriteLine("6. Exit");
                Console.WriteLine("============================================");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Task 1: Employees Between Dates");
                        DateTime d1, d2;
                        Console.Write("Enter Date 1 (yyyy-mm-dd): ");
                        d1 = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter Date 2 (yyyy-mm-dd): ");
                        d2 = Convert.ToDateTime(Console.ReadLine());
                        obj.GetTransaction(d1, d2);
                        break;

                    case 2:
                        Console.WriteLine("Task 2: Get Common Records");
                        Console.Write("Enter Department ID: ");
                        int deptid = Convert.ToInt32(Console.ReadLine());
                        obj.GetCommonRecords(deptid);
                        break;

                    case 3:
                        Console.WriteLine("Task 3: Insert Records Using Transaction");
                        obj.InsertRecordsusingtrans();
                        break;

                    case 4:
                        Console.WriteLine("Task 4: Scope Identity Insert + Fetch");
                        obj.ScopeQuery();
                        break;

                    case 5:
                        Console.WriteLine("Task 5: Multi-Result Reader");
                        obj.DoubleRead();
                        break;

                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();

            } while (choice != 6);

        }
    }
}
