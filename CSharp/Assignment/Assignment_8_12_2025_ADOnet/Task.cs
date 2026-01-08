using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Assignment_8_12_2025_ADOnet
{
    public class Task
    {
        SqlConnection con = new SqlConnection("Integrated Security = true;Database = ADOnet;Server=(localdb)\\MSSQLLocalDB");

        /// Task 1 ///
        /* Public void GetTransactions(d1 DateTime  , d2 DateTime) 
         { 
           // logic to display all records from Employees who date of join  between 
           2 dates using procedures 
         } */

        public void GetTransaction(DateTime d1, DateTime d2)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@d1", d1);
                cmd.Parameters.AddWithValue("@d2", d2);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}\t\t{dr[2]}\t\t{dr[3]}\t\t{dr[4]}");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /* Public void GetCommonRecords(int id) 
         { 
           // logic to display common records from Employee and department 
           based on id  
         } */

        public void GetCommonRecords(int id)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetCommonRecords", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptid", id);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}\t\t{dr[2]}\t\t{dr[3]}\t\t{dr[4]} {dr[5]}");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /* Public void InsertRecordsusingtrans() 
           { 
             // logic to insert records to employee and department using transaction 
           } */

        public void InsertRecordsusingtrans()
        {
            con.Open();
            SqlTransaction tr = con.BeginTransaction();

            try
            {
                string name;
                double salary;
                DateTime date;
                int DeptId;
                string DeptName;

                Console.WriteLine();
                Console.Write("\nEnter the EmpName : ");
                name = Console.ReadLine();

                Console.Write("Enter the Salary : ");
                salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the Joining Date (yyyy-mm-dd): ");
                date = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter the DepartmentId : ");
                DeptId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the DeptName : ");
                DeptName = Console.ReadLine();

                SqlCommand cmd1 = new SqlCommand("insert into Department values(@deptid, @deptname)", con, tr);
                cmd1.Parameters.AddWithValue("@deptid", DeptId);
                cmd1.Parameters.AddWithValue("@deptname", DeptName);
                int rowaffected1 = cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("insert into Employee values(@name, @salary, @date, @deptid)", con, tr);
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@salary", salary);
                cmd2.Parameters.AddWithValue("@date", date);
                cmd2.Parameters.AddWithValue("@deptid", DeptId);
                int rowaffected2 = cmd2.ExecuteNonQuery();

                Console.WriteLine("Total Records Inserted in Department " + rowaffected1);
                Console.WriteLine("Total Records Inserted in Employee " + rowaffected2);

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                Console.Write("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /* Connected Insert + Fetch New Identity 
        For a Employee table with an identity primary key: 
        • Insert a new Employee using INSERT  command. 
        • Immediately fetch the newly inserted identity using: 
        o SCOPE_IDENTITY() 
        • Validate that the ID exists by fetching it again with a new command. */

        public void ScopeQuery()
        {
            con.Open();
            try
            {
                string name;
                double salary;
                DateTime date;
                int DeptId;
                string DeptName;

                Console.WriteLine();
                Console.Write("\nEnter the EmpName : ");
                name = Console.ReadLine();

                Console.Write("Enter the Salary : ");
                salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the Joining Date (yyyy-mm-dd): ");
                date = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter the DepartmentId : ");
                DeptId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the DeptName : ");
                DeptName = Console.ReadLine();

                SqlCommand cmd = new SqlCommand("insert into Department values(@deptid,@deptname);" + "insert into Employee values(@name,@salary,@date,@deptid);" + "select scope_identity();",con);
                Console.WriteLine("Inserted Successfully...\n");

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@deptid", DeptId);
                cmd.Parameters.AddWithValue("@deptname", DeptName);
                object scope_id = cmd.ExecuteScalar();
                int newEmpId = Convert.ToInt32(scope_id);

                SqlCommand cmd2 = new SqlCommand("select * from Employee where EmpID = @id",con);

                cmd2.Parameters.AddWithValue("@id", newEmpId);
                SqlDataReader dr = cmd2.ExecuteReader();

                while(dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}\t\t{dr[2]}\t\t{dr[3]}\t\t{dr[4]}");
                }

            }
            catch(Exception ex)
            {
                Console.Write("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /* Multi-Result Reader with Joins 
         A company has Employees and Department tables. 
         Write a C# program that: 
         • Executes a single SqlCommand that returns two result sets: 
         1. List of employees 
         2. List of Departments 
         • Reads first result set via SqlDataReader.Read(), then moves to the next 
         using NextResult(). */

        public void DoubleRead()
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Employee;select * from Department", con);
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("Employee Table");
                while(dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}\t\t{dr[2]}\t\t{dr[3]}\t\t{dr[4]}");
                }

                Console.WriteLine("Department Table");
                dr.NextResult();
                while(dr.Read())
                {
                    Console.WriteLine($"{dr[0]}\t\t{dr[1]}");
                }

            }
            catch(Exception ex)
            {
                Console.Write("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void GetEmployeeDetailsUsingSP()
        {
            try
            {
                // Check connection state
                if (con.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Opening Connection...");
                    con.Open();
                }

                Console.WriteLine("\n----- Get Employee Details Using Stored Procedure -----\n");

                // Dynamic input
                Console.Write("Enter Employee ID : ");
                int empid = Convert.ToInt32(Console.ReadLine());

                // SqlCommand with procedure
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeDet", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // INPUT PARAMETER
                cmd.Parameters.AddWithValue("@Empid", empid);

                // OUTPUT PARAMETERS
                SqlParameter doj = new SqlParameter("@DateofJoin", SqlDbType.Date);
                doj.Direction = ParameterDirection.Output;

                SqlParameter dept = new SqlParameter("@Department", SqlDbType.VarChar, 100);
                dept.Direction = ParameterDirection.Output;

                // Add output params
                cmd.Parameters.Add(doj);
                cmd.Parameters.Add(dept);

                // Execute the command
                cmd.ExecuteNonQuery();

                // Retrieve output values
                string dateJoin = doj.Value != DBNull.Value ? Convert.ToDateTime(doj.Value).ToString("yyyy-MM-dd") : "Not Found";
                string department = dept.Value != DBNull.Value ? dept.Value.ToString() : "Not Found";

                // Display formatted summary
                Console.WriteLine("\n----- Employee Summary -----");
                Console.WriteLine($"Employee ID      : {empid}");
                Console.WriteLine($"Date of Joining  : {dateJoin}");
                Console.WriteLine($"Department ID    : {department}");
                Console.WriteLine("----------------------------\n");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("\nSQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nGeneral Error : " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Closing Connection...");
                    con.Close();
                }
            }
        }


    }
}
