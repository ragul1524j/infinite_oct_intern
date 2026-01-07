<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment_ASP.NET.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>User Validator Form</h2>

            <label>Name</label>
            <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Name is Required"
                CssClass="error" />

            <label>Family Name</label>
            <asp:TextBox ID="txtFamily" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtFamily"
                ErrorMessage="Family Name is Required"
                CssClass="error" />

            <asp:CompareValidator runat="server"
                ControlToValidate="txtName"
                ControlToCompare="txtFamily"
                Operator="NotEqual"
                ErrorMessage="Name must be different from Family Name"
                CssClass="error" />

            <label>Address</label>
            <asp:TextBox ID="txtAddress" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="Address is Required"
                CssClass="error" />
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtAddress"
                ValidationExpression=".{2,}"
                ErrorMessage="Address must be at least 2 characters"
                CssClass="error" />

            <label>City</label>
            <asp:TextBox ID="txtCity" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtCity"
                ErrorMessage="City is Required"
                CssClass="error" />
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtCity"
                ValidationExpression=".{2,}"
                ErrorMessage="City must be at least 2 characters"
                CssClass="error" />

            <label>Zip Code</label>
            <asp:TextBox ID="txtZip" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtZip"
                ErrorMessage="Zip Code is Required"
                CssClass="error" />
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtZip"
                ValidationExpression="^\d{5}$"
                ErrorMessage="Zip code must be exactly 5 digits"
                CssClass="error" />

            <label>Phone</label>
            <asp:TextBox ID="txtPhone" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtPhone"
                ErrorMessage="Phone is Required"
                CssClass="error" />
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtPhone"
                ValidationExpression="^(\d{2}|\d{3})-\d{7}$"
                ErrorMessage="Phone must be XX-XXXXXXX or XXX-XXXXXXX"
                CssClass="error" />

            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is Required"
                CssClass="error" />
            <asp:RegularExpressionValidator runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="Invalid email format"
                CssClass="error" />

            <asp:Button ID="btnCheck" runat="server"
                Text="Check"
                CssClass="btn"
                OnClick="btnCheck_Click" />

            <asp:Label ID="lblResult" runat="server" CssClass="success" />
        </div>
    </form>
</body>
</html>
