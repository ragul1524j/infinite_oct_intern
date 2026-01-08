using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_9_12_2025_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Disconnected disconnected = new Disconnected();
            //disconnected.ShowDetails();
            //disconnected.EmployeeFilter();
            //disconnected.ShowTotalTables();
            //disconnected.CopyDepartment();
            //disconnected.MergeTables();
            disconnected.ReadXml();
        }
    }
}
