using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBoardBilling
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();


            if (username == "admin" && password == "admin123")
            {
                Session["Admin"] = true;
                Response.Redirect("Default.aspx");
            }
            else
            {

                lblError.Text = "Invalid username or password";
                lblError.Visible = true;
            }
        }
    }
}