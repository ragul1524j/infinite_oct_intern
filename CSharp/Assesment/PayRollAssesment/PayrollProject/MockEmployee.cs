
namespace PayrollProject
{
    public class MockEmployeeDataReader : IEmployeeDataReader
    {
        public EmployeeRecord GetEmployeeRecord(int employeeId)
        {
            
            if (employeeId == 101)
            {
                return new EmployeeRecord
                {
                    Id = 101,
                    Name = "Logesh",
                    Role = "Developer",
                    IsVetern = false
                };
            }

            if (employeeId == 102)
            {
                return new EmployeeRecord
                {
                    Id = 102,
                    Name = "Prathees",
                    Role = "Manager",
                    IsVetern = true
                };
            }

            if (employeeId == 103)
            {
                return new EmployeeRecord
                {
                    Id = 103,
                    Name = "Waseef",
                    Role = "Intern",
                    IsVetern = false
                };
            }

            
            return new EmployeeRecord
            {
                Id = employeeId,
                Name = "Unknown",
                Role = "Unknown",
                IsVetern = false
            };
        }
    }
}
