<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportPage.aspx.cs" Inherits="WebApplication1.ReportPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Report</title>
</head>
<body>
    <form id="form1" runat="server"><center>
        <h2>Product Report (Products with Attributes)</h2>
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="800px">
            <Columns>
                <asp:BoundField DataField="prod_id" HeaderText="Product ID" />
                <asp:BoundField DataField="prod_name" HeaderText="Product Name" />
                <asp:BoundField DataField="price" HeaderText="Price" />
                <asp:BoundField DataField="cat_name" HeaderText="Category" />
                <asp:BoundField DataField="attributes" HeaderText="Attributes" />
            </Columns>
        </asp:GridView></center>
    </form>
</body>
</html>
