using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee{ EmpId = 101,Name = "Arun",Department = "IT",Salary = 35000,Experience = 6},
                new Employee{ EmpId = 102,Name = "Kavya",Department = "HR",Salary = 48000,Experience = 3},
                new Employee{ EmpId = 103,Name = "Ajay",Department = "Finance",Salary = 52000,Experience = 7},
                new Employee{ EmpId = 104,Name = "Meera",Department = "Sales",Salary = 45000,Experience = 2},
                new Employee{ EmpId = 105,Name = "Dinesh",Department = "IT",Salary = 72000,Experience = 8},
                new Employee{ EmpId = 106,Name = "Aishwarya",Department = "HR",Salary = 55000,Experience = 4},
                new Employee{ EmpId = 107,Name = "Vijay",Department = "Finance",Salary = 60000,Experience = 9},
                new Employee{ EmpId = 108,Name = "Anitha",Department = "Sales",Salary = 30000,Experience = 1},
                new Employee{ EmpId = 109,Name = "Suresh",Department = "IT",Salary = 90000,Experience = 10},
                new Employee{ EmpId = 110,Name = "Ragul",Department = "Sales",Salary = 50000,Experience = 5}
            };

            Console.WriteLine("ALL Emplyoees\n");
            DisplayList(employeeList);

            var salaryAbove50k = employeeList.Where(emp => emp.Salary > 50000).ToList();
            var itEmployees = employeeList.Where(emp => emp.Department == "IT").ToList();
            var experienceAbove = employeeList.Where(emp => emp.Experience > 5).ToList();
            var namesStartingWithA = employeeList.Where(emp => emp.Name.StartsWith("A")).ToList();

            Console.WriteLine("\nEmployees Salary > 50000\n");
            DisplayList(salaryAbove50k);

            Console.WriteLine("\nIT Department Employees\n");
            DisplayList(itEmployees);

            Console.WriteLine("\nExperience > 5 Years\n");
            DisplayList(experienceAbove);

            Console.WriteLine("\nNames Starting with 'A\n");
            DisplayList(namesStartingWithA);


            var sortedByName = employeeList.OrderBy(emp => emp.Name).ToList();
            var sortedBySalary = employeeList.OrderByDescending(emp => emp.Salary).ToList();
            var sortedByExperience = employeeList.OrderBy(emp => emp.Experience).ToList();

            Console.WriteLine("\nSorted By Name (A - Z)\n");
            DisplayList(sortedByName);

            Console.WriteLine("\nSorted By Salary (High - low)\n");
            DisplayList(sortedBySalary);

            Console.WriteLine("Sorted By Experience (Low - High)\n");
            DisplayList(sortedByExperience);

            var promotionList = employeeList.Where(emp => emp.Experience >= 8).ToList();

            Console.WriteLine("Promotion List (Experience >= 8 years)");
            DisplayList(promotionList);

            Console.ReadLine();
        }
        static void DisplayList(List<Employee> employees)
        {
            if(employees.Count == 0)
            {
                Console.WriteLine("No employees found.\n");
                return;
            }

            foreach (var emp in employees)
            {
                emp.Display();
                Console.WriteLine();
                
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine();

        }
    }
}
