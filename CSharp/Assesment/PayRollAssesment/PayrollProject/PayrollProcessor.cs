
using System;
using System.Collections.Generic;

namespace PayrollProject
{
    public class PayrollProcessor
    {
       
        private static readonly Dictionary<int, decimal> BaseSalaries = new Dictionary<int, decimal>
        {
            [101] = 65000m,
            [102] = 120000m,
            [103] = 30000m
        };

        private readonly IEmployeeDataReader _employeeReader;

        public PayrollProcessor(IEmployeeDataReader employeeReader)
        {
            _employeeReader = employeeReader ?? throw new ArgumentNullException(nameof(employeeReader));
        }

        public decimal CalculateTotalCompensation(int employeeId)
        {
            var emp = _employeeReader.GetEmployeeRecord(employeeId);

            
            decimal baseSalary;
            if (!BaseSalaries.TryGetValue(employeeId, out baseSalary))
            {
                baseSalary = 0m;
            }

            // Bonus logic with if/else (as requested)
            decimal bonus = 0m;

            if (emp.Role == "Manager" && emp.IsVetern == true)
            {
                bonus = 10_000m;
            }
            else if (emp.Role == "Manager" && emp.IsVetern == false)
            {
                bonus = 5_000m;
            }
            else if (emp.Role == "Developer")
            {
                bonus = 2_000m;
            }
            else if (emp.Role == "Intern")
            {
                bonus = 500m;
            }
            else
            {
                bonus = 0m;
            }

            return baseSalary + bonus;
        }
    }
}
