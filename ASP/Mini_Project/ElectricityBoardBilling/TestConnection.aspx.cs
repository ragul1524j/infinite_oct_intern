using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;    


namespace ElectricityBoardBilling
{
    public partial class TestConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBHandler.GetConnection();
                con.Open();

                lblResult.Text = "✅ Database connection successful";
                lblResult.ForeColor = System.Drawing.Color.Green;

                con.Close();
            }
            catch (Exception ex)
            {
                lblResult.Text = "❌ Database connection failed<br/>" + ex.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}