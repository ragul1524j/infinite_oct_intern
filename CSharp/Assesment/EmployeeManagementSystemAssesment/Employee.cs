using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        public int Experience { get; set; }

        public void Display()
        {
            Console.WriteLine($"EmployeeId : {EmpId,-5}\nEmpName : {Name,-12}\nDepartment : {Department,-12}\nSalary : {Salary,-10}\nExperience : {Experience}");
        }

    }
}
