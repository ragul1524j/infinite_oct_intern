using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOAssesent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectedArchitecture connectedArchitecture = new ConnectedArchitecture();
            connectedArchitecture.DisplayAllCourses();
            connectedArchitecture.AddNewStudent();
            connectedArchitecture.SearchStudentsByDepartment();
            connectedArchitecture.EnrolledCourseOfStudent();
            connectedArchitecture.GradeUpdate();


            DisconnectedArchitecture disconnected = new DisconnectedArchitecture();
            disconnected.ShowDataTabular();
            disconnected.ModifyCourse();
            disconnected.AddCourse();
            disconnected.DeleteStudent();
        }
    }
}
