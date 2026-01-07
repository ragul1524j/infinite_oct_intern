using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBoardBilling
{
    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string conn =
                    ConfigurationManager.ConnectionStrings["EBConnection"].ConnectionString;

                SqlConnection con = new SqlConnection(conn);
                return con;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating database connection", ex);
            }
        }
    }
}