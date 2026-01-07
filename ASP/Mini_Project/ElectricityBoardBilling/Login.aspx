<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="ElectricityBoardBilling.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Login</title>

    <style>
      
        body {
            margin: 0;
            min-height: 100vh;
            font-family: Arial, Helvetica, sans-serif;
            background-color: #E6ECFF;  
            display: flex;
            justify-content: center;
            align-items: center;
        }

       
        .login-card {
            width: 300px;                 
            padding: 30px 26px 36px;
            background-color:#f8f9fa;
            border-radius: 10px;
            box-shadow: 0 12px 24px rgba(0,0,0,0.15);
        }

        .login-card h2 {
            text-align: center;
            color: #0A0DEB;
            margin-bottom: 24px;
            font-size: 20px;
            font-weight: 600;
        }

        .form-group {
            margin-bottom: 14px;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
            font-size: 13px;
            font-weight: 600;
            color: #494D5F;
        }

       
        .login-input {
            width: 100%;
            height: 32px;               
            padding: 4px 8px;
            border-radius: 5px;
            border: 1px solid #D0D0F4;
            font-size: 13px;
            box-sizing: border-box;
        }

        .login-input:focus {
            outline: none;
            border-color: #0A0DEB;
            box-shadow: 0 0 0 2px rgba(10,13,235,0.15);
        }

     
        .login-btn {
            width: 130px;              
            height: 40px;
            margin: 22px auto 18px;
            display: block;
            background-color: #0A0DEB;
            color: #ffffff;
            border: none;
            border-radius: 20px;
            cursor: pointer;
            font-size: 13px;
            font-weight: 600;
        }

        .login-btn:hover {
            background-color: #0909c9;
        }

       
        .error-msg {
            text-align: center;         
            color: #D9534F;
            font-size: 13px;
            font-weight: 500;
            margin-top: 6px;
        }
    </style>
</head>

<body>
<form runat="server" autocomplete="off">

    <div class="login-card">

        <h2>Admin Login</h2>

        <div class="form-group">
            <label class="form-label">Username</label>
            <asp:TextBox ID="txtUsername"
                runat="server"
                CssClass="login-input" />
        </div>

        <div class="form-group">
            <label class="form-label">Password</label>
            <asp:TextBox ID="txtPassword"
                runat="server"
                CssClass="login-input"
                TextMode="Password" />
        </div>

        <asp:Button ID="btnLogin"
            runat="server"
            Text="Login"
            CssClass="login-btn"
            OnClick="btnLogin_Click" />

        <asp:Label ID="lblError"
            runat="server"
            CssClass="error-msg"
            Visible="false"></asp:Label>

    </div>

</form>
</body>
</html>
