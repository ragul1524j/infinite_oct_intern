using ElectricityBoardBilling.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBoardBilling
{
    public partial class ViewLastNBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
         
            cvCount.IsValid = true;

            
            if (!Page.IsValid)
                return;

            int n = int.Parse(txtCount.Text.Trim());

            
            if (n <= 0)
            {
                cvCount.IsValid = false;
                return;
            }
            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> bills = board.Generate_N_BillDetails(n);

            gvBills.DataSource = bills;
            gvBills.DataBind();
            gvBills.Visible = true;
        }

    }
}