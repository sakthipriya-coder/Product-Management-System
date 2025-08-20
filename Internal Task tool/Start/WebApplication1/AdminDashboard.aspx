<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebApplication1.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0; padding: 0;
            background-color: #f4f4f9;
        }
        .header {
            background: #2c3e50;
            color: white;
            padding: 15px;
            text-align: center;
        }
        .nav {
            background: #34495e;
            padding: 10px;
            display: flex;
            justify-content: center;
        }
        .nav a {
            color: white;
            margin: 0 15px;
            text-decoration: none;
            font-weight: bold;
        }
        .nav a:hover {
            text-decoration: underline;
        }
        .container {
            padding: 20px;
        }
        .card {
            background: white;
            border-radius: 5px;
            padding: 20px;
            margin: 15px 0;
            box-shadow: 0 2px 5px rgba(0,0,0,0.2);
        }
        .logout {
            float: right;
            margin-top: -35px;
            margin-right: 20px;
        }
        .logout a {
            color: #e74c3c;
            font-weight: bold;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <div class="header">
            <h1>Admin Dashboard</h1>
            <div class="logout">
                <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">Logout</asp:LinkButton>
            </div>
        </div>

        <!-- Navigation -->
        <div class="nav">
            <a href="CategoryPage.aspx">Manage Categories</a>
            <a href="AttributePage.aspx">Manage Attributes</a>
            <a href="ProductPage.aspx">Manage Products</a>
            <a href="ProductAttributeValue.aspx">Manage Product Attributes</a> 
            <a href="ReportPage.aspx">Reports</a>
        </div>

        <!-- Main Container -->
        <div class="container">
            <div class="card">
                <h2>Welcome, Admin!</h2>
                <p>Select an option from above to manage your application.</p>
            </div>

            <div class="card">
                <h3>Quick Stats</h3>
                <p>Total Categories: <asp:Label ID="lblCategoryCount" runat="server" /></p>
                <p>Total Products: <asp:Label ID="lblProductCount" runat="server" /></p>
                <p>Total Attributes: <asp:Label ID="lblAttributeCount" runat="server" /></p>
            </div>
        </div>
    </form>
</body>
</html>
