using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_ASP.NET
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add(new ListItem("Select Product", "0"));
                ddlProducts.Items.Add(new ListItem("Laptop", "Laptop"));
                ddlProducts.Items.Add(new ListItem("Mobile", "Mobile"));
                ddlProducts.Items.Add(new ListItem("Headphones", "Headphones"));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedValue == "Laptop")
            {
                imgProduct.ImageUrl = "https://m.media-amazon.com/images/I/71TPda7cwUL._SX679_.jpg";
            }
            else if (ddlProducts.SelectedValue == "Mobile")
            {
                imgProduct.ImageUrl = "https://m.media-amazon.com/images/I/81fxjeu8fdL._SX679_.jpg";
            }
            else if (ddlProducts.SelectedValue == "Headphones")
            {
                imgProduct.ImageUrl = "https://m.media-amazon.com/images/I/61CGHv6kmWL._SX679_.jpg";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedValue == "Laptop")
            {
                lblPrice.Text = "Price: ₹60,000";
            }
            else if (ddlProducts.SelectedValue == "Mobile")
            {
                lblPrice.Text = "Price: ₹25,000";
            }
            else if (ddlProducts.SelectedValue == "Headphones")
            {
                lblPrice.Text = "Price: ₹3,000";
            }
            else
            {
                lblPrice.Text = "Please select a product";
            }
        }
    }
}