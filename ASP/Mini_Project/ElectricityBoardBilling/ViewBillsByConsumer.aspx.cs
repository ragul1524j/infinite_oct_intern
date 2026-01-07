using ElectricityBoardBilling.Backend;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBoardBilling
{
    public partial class ViewBillsByConsumer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string consumerNo = txtConsumerNumber.Text.Trim();
            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> bills = board.GetBillsByConsumer(consumerNo);
            if(bills.Count > 0)
            {
                gvBills.DataSource = bills;
                gvBills.DataBind();
                gvBills.Visible = true;
                lblMessage.Visible = false;
            }
            else
            {
                gvBills.Visible=false;
                lblMessage.Text = "No bills found for this Consumer Number";
                lblMessage.Visible = true;
            }
        }
    }
}