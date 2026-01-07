<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestConnection.aspx.cs" Inherits="ElectricityBoardBilling.TestConnection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test DB Connection</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnTest" runat="server"
            Text="Test Database Connection"
            OnClick="btnTest_Click" />
        <br /><br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </form>
</body>
</html>
