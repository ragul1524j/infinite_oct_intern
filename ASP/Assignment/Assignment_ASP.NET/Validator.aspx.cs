using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_ASP.NET
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                lblResult.Text = "All data is Valid ";
            }
            else
            {
                lblResult.Text = "Data is Invalid";
            }
        }
    }
}