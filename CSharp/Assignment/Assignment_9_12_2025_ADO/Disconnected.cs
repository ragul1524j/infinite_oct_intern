using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_9_12_2025_ADO
{
   
    public class Disconnected
    {
        SqlConnection con = new SqlConnection("Integrated Security = true;Database = ADOnet;Server=(localdb)\\MSSQLLocalDB");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        



        /* Task-1
Develop a code to print all record from Employee and Departmen */

        public void ShowDetails()
        {
            SqlDataAdapter daEmp = new SqlDataAdapter("select * from Employee", con);
            daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daEmp.Fill(ds, "Employee");

            SqlDataAdapter daDept = new SqlDataAdapter("select * from Department", con);
            daDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDept.Fill(ds, "Department");

            Console.WriteLine("\nEmployee Table\n");
            DataTable EmpTable = ds.Tables["Employee"];

            for(int i=0;i<EmpTable.Rows.Count;i++)
            {
                for(int j=0;j<EmpTable.Columns.Count;j++)
                {
                    Console.Write(EmpTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nDepartment\n");
            DataTable DeptTable = ds.Tables["Department"];

            for(int i=0;i<DeptTable.Rows.Count;i++)
            {
                for(int j=0;j < DeptTable.Columns.Count;j++)
                {
                    Console.Write(DeptTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n==================================");

        }

        /*    Task-2
From a Employee Table
• Create DataView having following conditions:
o Salary > 47000
o Department = 10
o EmployeeName Starts with 'M'
• Apply sorting */

        public void EmployeeFilter()
        {
            if (!ds.Tables.Contains("Employee"))
            {
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT * FROM Employee", con);
                daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                daEmp.Fill(ds, "Employee");
            }

            DataTable EmpTable = ds.Tables["Employee"];
            DataView dv = new DataView(EmpTable);
            dv.RowFilter = "Salary > 47000 and DeptID = 10 and EmpName like 'M%'";
            dv.Sort = "EmpName ASC";

            Console.WriteLine("\n Filtered Employee Table \n");
            for(int i=0;i<dv.Count;i++)
            {
                for(int j=0;j<dv.Table.Columns.Count;j++)
                {
                    Console.Write(dv[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n==================================");

        }

        /* Task-3
Write a code to print to show total no of tables present in dataset */

        public void ShowTotalTables()
        {
            DataTable dt = new DataTable();

            da = new SqlDataAdapter(
                "SELECT COUNT(*) AS TotalTables FROM sys.tables", con);

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine(
                    "The Total Number of Tables in Database : " +
                    dt.Rows[0]["TotalTables"]);
            }
            else
            {
                Console.WriteLine("No data returned from database.");
            }
        }

        /*   Develop a code to copy data of SqlDataReader object To DataTable object and 
print all data using DataTable Object (use Department Table) Hint : use 
dt.Load() */

        public void CopyDepartment()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Department", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            Console.WriteLine("\n Department Details \n");
            for(int i=0;i<dt.Rows.Count;i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /*   Task-5
Develop a code to display records from customers and orders . 
a. Create ds1 object which stores customers details 
b. Create ds2 object which stores orders details 
c. Merge ds1 with ds2 using merge method and display records from both the 
table using ds1 */

        public void MergeTables()
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            SqlDataAdapter daEmp = new SqlDataAdapter("Select * from Employee", con);
            daEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daEmp.Fill(ds1, "Employee");
         

            SqlDataAdapter daDept = new SqlDataAdapter("Select * from Department", con);
            daDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDept.Fill(ds2, "Department");

            ds1.Merge(ds2);

            DataTable EmpTable = ds1.Tables[0];
            Console.WriteLine("\nEmployee Table\n");
            for (int i=0;i<EmpTable.Rows.Count;i++)
            {
                for(int j=0;j<EmpTable.Columns.Count;j++)
                {
                    Console.Write(EmpTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
           

            DataTable DeptTable = ds1.Tables[1];
            Console.WriteLine("\nDepartment Table\n");
            for (int i=0;i<DeptTable.Rows.Count;i++)
            {
                for(int j=0;j<DeptTable.Columns.Count;j++)
                {
                    Console.Write(DeptTable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /* Task-6
        Develop a code to Read Data of Xml File (use ds.Read() Method) and print the 
        same in console application
        <CUSTOMER>
        <CUST>
        <CUSTID>C001</CUSTID>
        <CUSTNAME>RAJ SHARMA</CUSTNAME>
        <CUSTADDRESS>BANGALORE</CUSTADDRESS>
        <PHONE>9967564497</PHONE>
        </CUST>
        <CUST>
        <CUSTID>C002</CUSTID>
        <CUSTNAME>VIJAY SHARMA</CUSTNAME>
        <CUSTADDRESS>BANGALORE</CUSTADDRESS>
        <PHONE>9967564497</PHONE>
        </CUST>
        </CUSTOMER */

        public void ReadXml()
        {
            ds.ReadXml(@"C:\Infinite_Training\Practice_Problems\Assignment_9_12_2025_ADO\customer.xml");

            DataTable dt = ds.Tables[0];

            Console.Write("\n Customer Xml \n");
            for(int i=0;i<dt.Rows.Count;i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }





    }
}
