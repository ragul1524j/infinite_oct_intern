using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ADOAssesent
{
    public class DisconnectedArchitecture
    {
        SqlConnection con = new SqlConnection("Integrated Security = true;Database = ADOnet;Server=(localdb)\\MSSQLLocalDB");
        DataSet ds = new DataSet();
        SqlDataAdapter da;




        /* Task 3.1 – Load Students and Courses into a DataSet 
Show the data in tabular format.  */
        public void ShowDataTabular()
        {
            Console.WriteLine("Task 3.1\n");
            SqlDataAdapter daStu = new SqlDataAdapter("select * from Students", con);
            daStu.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daStu.Fill(ds, "Students");

            SqlDataAdapter daCou = new SqlDataAdapter("select * from Courses", con);
            daCou.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daCou.Fill(ds, "Courses");

            DataTable dtStu = ds.Tables["Students"];

            Console.WriteLine("\n Student Table \n");
            for(int i=0;i<dtStu.Rows.Count;i++)
            {
                for(int j=0;j<dtStu.Columns.Count;j++)
                {
                    Console.Write(dtStu.Rows[i][j] + " ");
                }
                Console.WriteLine();
            }

            DataTable dtCou = ds.Tables["Courses"];
            Console.WriteLine("\n Course Table \n");

            for (int i=0;i<dtCou.Rows.Count;i++)
            {
                for(int j=0;j<dtCou.Columns.Count;j++)
                {
                    Console.Write(dtCou.Rows[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");

        }


        /*     Task 3.2 – Modify course credits (Disconnected Mode) 
Steps: 
1. Load Courses into DataSet 
2. Ask user for CourseId 
3. Update Credits 
4. Use SqlCommandBuilder to update DB */


        public void ModifyCourse()
        {
            Console.WriteLine("Task 3.2\n");

            SqlDataAdapter daMod = new SqlDataAdapter("select * from Courses", con);
            daMod.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daMod.Fill(ds, "Courses");

            DataTable dtCourse = ds.Tables["Courses"];

            Console.Write("Enter the CourseID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the credit to Update : ");
            int credit = Convert.ToInt32(Console.ReadLine());
            DataRow row = dtCourse.Rows.Find(id);
            if(row == null)
            {
                Console.WriteLine("CousedId Not Found");
                return;
            }

            row["Credits"] = credit;

            SqlCommandBuilder cb = new SqlCommandBuilder(daMod);
            int roeaffected = daMod.Update(ds, "Courses");
            if (roeaffected > 0)
            {
                Console.WriteLine("Credit Updated Successfully");
            }
            else
            {
                Console.WriteLine("Credit Updation Failed");
            }
            Console.WriteLine("\n");
        }

        /*       Task 3.3 – Insert a new course (Disconnected Mode) 
Add new row → Update DB. */

        public void AddCourse()
        {
            Console.WriteLine("Task 3.3\n");

            Console.Write("Enter the CourseName : ");
            string coursename = Console.ReadLine();
            Console.Write("Enter the Credits : ");
            int credit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Semester : ");
            string semester = Console.ReadLine();

            SqlDataAdapter daIns = new SqlDataAdapter("select * from Courses", con);
            daIns.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daIns.Fill(ds, "Courses");
            DataTable dtCourse = ds.Tables["Courses"];

            DataRow newRow = dtCourse.NewRow();
            newRow["CourseName"] = coursename;
            newRow["Credits"] = credit;
            newRow["Semester"] = semester;

            dtCourse.Rows.Add(newRow);
            SqlCommandBuilder cb = new SqlCommandBuilder(daIns);
            int rowsAffected = daIns.Update(ds, "Courses");
           if(rowsAffected > 0)
            {
                Console.WriteLine("Insertion is Completed");
            }
            else
            {
                Console.WriteLine("Insertion Failed");
            }
            Console.WriteLine("\n");
        }


        /*  Task 3.4 – Delete a student (Disconnected Mode) 
Delete student record inside DataTable. */

        public void DeleteStudent()
        {
            Console.WriteLine("Task 3.4\n");

            SqlDataAdapter daStudent = new SqlDataAdapter("select * from Students", con);
            daStudent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daStudent.Fill(ds, "Students");

            DataTable dtStudent = ds.Tables["Students"];

            Console.WriteLine("Enter the Student id to Delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            DataRow find = dtStudent.Rows.Find(id);
            if (find == null)
            {
                Console.WriteLine("Student Not Found!");
                return;
            }

            find.Delete();
            SqlCommandBuilder cb = new SqlCommandBuilder(daStudent);
            int roweffected = daStudent.Update(ds, "Students");
            if(roweffected > 0)
            {
                Console.WriteLine("Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Deletion Failed");
            }

            Console.WriteLine("\n");

        }

    }
}
