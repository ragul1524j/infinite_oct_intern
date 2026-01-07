<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment_ASP.NET.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
    <link rel="stylesheet" href="product.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Select Product</h2>

            <asp:DropDownList ID="ddlProducts" runat="server"
                AutoPostBack="true" CssClass="dropdown"
                OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Image ID="imgProduct" runat="server" CssClass="product-img" />

            <asp:Button ID="btnPrice" runat="server"
                Text="Get Price"
                CssClass="btn"
                OnClick="btnPrice_Click" />
            <asp:Label ID="lblPrice" runat="server" CssClass="price"></asp:Label>
        </div>
    </form>
</body>
</html>
