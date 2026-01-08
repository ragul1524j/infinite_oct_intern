using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOAssesent
{
    public class ConnectedArchitecture
    {
        SqlConnection con = new SqlConnection("Integrated Security = true;Database = ADOnet;Server=(localdb)\\MSSQLLocalDB");



        /*  
Task 2.1 – Display all courses 
Show: CourseId, CourseName, Credits, Semester  */

        public void DisplayAllCourses()
        {
            Console.WriteLine("Task 2.1\n");
           
            try
            {
                con.Open();
                string sql = "select CourseId, CourseName, Credits, Semester from Courses";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("CourseId   CourseName   Credits   Semester");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["CourseId"]}\t\t{dr["CourseName"]}\t\t{dr["Credits"]}\t\t{dr["Semester"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("\n");
        }

        //Task 2.2
        public void AddNewStudent()
        {
            Console.WriteLine("Task 2.2\n");

            try
            {
                Console.Write("Enter the Name : ");
                string name = Console.ReadLine();
                Console.Write("Enter Email : ");
                string email = Console.ReadLine();
                Console.Write("Enter Department Name : ");
                string dept = Console.ReadLine();
                Console.Write("Enter Year of Studying : ");
                int year = Convert.ToInt32(Console.ReadLine());
                con.Open();
                string sql = "insert into Students (FullName, Email, Department, YearOfStudy) " +
                             "values (@FullName, @Email, @Dept, @Year)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Dept", dept);
                cmd.Parameters.AddWithValue("@Year", year);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine("Student added successfully.");
                }
                else
                {
                    Console.WriteLine("No record inserted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("\n");

        }


        /*               Task 2.3 – Search students by department Input example: “Computer Science” 
         *               Display matching students
         *               .*/

        public void SearchStudentsByDepartment()
        {
            Console.WriteLine("Task 2.3\n");


            try
            {
                Console.Write("Enter Department: ");
                string deptName = Console.ReadLine();
                con.Open();
                string query = "select StudentId, FullName, Email, YearOfStudy from Students where Department = @d";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d", deptName);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("\nStudents from " + deptName + ":");
                bool any = false;
                while (dr.Read())
                {
                    any = true;

                    Console.WriteLine($"{dr["StudentId"]}\t\t{dr["FullName"]}\t\t{dr["Email"]}\t\tYear: {dr["YearOfStudy"]}");
                }
                if (!any)
                {
                    Console.WriteLine("No matching students found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("\n");

        }

        /* Task 2.4 – Display enrolled courses for a student 
Input: StudentId 
Output example: 
Course Name | Credits | Enroll Date | Grade */

        public void EnrolledCourseOfStudent()
        {
            Console.WriteLine("Task 2.4\n");

            try
            {
                Console.Write("Enter the Student Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                con.Open();
                SqlCommand cmd = new SqlCommand(
                            "select c.CourseName, c.Credits, e.EnrollDate, e.Grade " +
                            "from Enrollments e inner join Courses c on e.CourseId = c.CourseId " +
                            "where e.StudentId = @id", con); cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("\nEnrolled Courses for Student " + id);
                bool found = false;

                while(dr.Read())
                {
                    found = true;
                    Console.WriteLine($"{dr["CourseName"]}\t\t{dr["Credits"]}\t\t{dr["EnrollDate"]}\t\t{dr["Grade"]}");
                }

                if(!found)
                {
                    Console.WriteLine("No Course Enrolled for this Student");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                con.Close();
            }
            Console.WriteLine("\n");

        }


        /*        Task 2.5 – Update grade (Connected Mode) Input: • EnrollmentId • 
         *        Grade (A/B/C/D/F) Update Enrollments table. */


        public void GradeUpdate()
        {
            Console.WriteLine("Task 2.5\n");

            try
            {
                Console.Write("Enter the Enrollment id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Grade : ");
                string grade = Console.ReadLine();
                con.Open();
                SqlCommand cmd = new SqlCommand("update Enrollments set Grade = @grade where EnrollmentId = @id",con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@grade", grade);

                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    Console.WriteLine("Grade Updatred Successfully");
                }
                else
                {
                    Console.WriteLine("Updation Failed");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("\n");

        }

    }
}
