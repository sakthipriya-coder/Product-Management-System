<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
     <style>
        body 
        {
             background: linear-gradient(135deg, #f4f7fc, #a1c4fd);
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f4f4f9;
        }
        .form-container {
            width: 429px;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
        </style>
</head>
<body style="background-color:#f0f0f0; font-family:Arial;">
    <form id="form1" runat="server">
        <div style="width:400px; margin:50px auto; padding:20px; background:white; border-radius:10px; box-shadow:0px 0px 10px gray;">

            <!-- Toggle Buttons -->
            <asp:Button ID="btnShowSignIn" runat="server" Text="Sign In" OnClick="btnShowSignIn_Click" />
            <asp:Button ID="btnShowSignUp" runat="server" Text="Sign Up" OnClick="btnShowSignUp_Click" />

            <hr />
           
            <!-- Sign In Panel -->
            <asp:Panel ID="pnlSignIn" runat="server" Visible="true">
                <h3>Sign In</h3>
                <asp:Label ID="Label1" Text="Username:" runat="server" /><br />
                <asp:TextBox ID="txtLoginUsername" runat="server" /><br /><br />

                <asp:Label ID="Label2" Text="Password:" runat="server" /><br />
                <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" /><br /><br />

                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </asp:Panel>

            <!-- Sign Up Panel -->
            <asp:Panel ID="pnlSignUp" runat="server" Visible="false">
                <h3>Sign Up</h3>
                <asp:Label ID="Label3" Text="Username:" runat="server" /><br />
                <asp:TextBox ID="txtSignupUsername" runat="server" /><br /><br />

                <asp:Label ID="Label4" Text="Password:" runat="server" /><br />
                <asp:TextBox ID="txtSignupPassword" runat="server" TextMode="Password" /><br /><br />

                <asp:Label ID="Label5" Text="Email:" runat="server" /><br />
                <asp:TextBox ID="txtSignupEmail" runat="server" /><br /><br />

                <asp:Label ID="Label6" Text="Phone:" runat="server" /><br />
                <asp:TextBox ID="txtSignupPhone" runat="server" /><br /><br />

                <asp:Label ID="Label7" Text="Address:" runat="server" /><br />
                <asp:TextBox ID="txtSignupAddress" runat="server" TextMode="MultiLine" Rows="3" /><br /><br />

                <asp:Button ID="btnSignup" runat="server" Text="Register" OnClick="btnSignup_Click" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
