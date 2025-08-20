<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="WebApplication1.ProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Products</title>
    <style>
        body { font-family: Arial; margin: 20px; background-color: #f4f4f9; }
        h2 { color: #333; }
        table { margin-top: 10px; }
        td { padding: 5px; }
        .btn { background: #4CAF50; color: white; padding: 6px 12px; border: none; cursor: pointer; }
        .btn:hover { background: #45a049; }
        .grid { margin-top: 20px; border: 1px solid #ccc; width: 80%; }
    </style>
</head>
<body>
    <form id="form1" runat="server"><center>
        <h2>Manage Products</h2>

        <table>
            <tr>
                <td>Product Name:</td>
                <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price:</td>
                <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Category:</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="btn" OnClick="btnAddProduct_Click" />
                </td>
            </tr>
        </table>

        <br />

        <!-- Product List -->
      <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="grid"
    DataKeyNames="prod_id"
    OnRowEditing="gvProducts_RowEditing"
    OnRowUpdating="gvProducts_RowUpdating"
    OnRowCancelingEdit="gvProducts_RowCancelingEdit"
    OnRowDeleting="gvProducts_RowDeleting">

    <Columns>
        <asp:BoundField DataField="prod_id" HeaderText="Product ID" ReadOnly="True" />
        <asp:BoundField DataField="prod_name" HeaderText="Product Name" />
        <asp:BoundField DataField="price" HeaderText="Price" />
        <asp:BoundField DataField="cat_name" HeaderText="Category" ReadOnly="True" />
        <%-- Edit/Delete Buttons --%>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>
</center>
    </form>
</body>
</html>
