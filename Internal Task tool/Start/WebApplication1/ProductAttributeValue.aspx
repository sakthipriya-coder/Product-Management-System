<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAttributeValue.aspx.cs" Inherits="WebApplication1.ProductAttributeValue" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Product Attributes</title>
</head>
<body>
    <form id="form1" runat="server"><center>
        <h2>Assign Attributes to Products</h2>
        <table>
            <tr>
                <td>Product:</td>
                <td>
                    <asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Attribute:</td>
                <td>
                    <asp:DropDownList ID="ddlAttribute" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Value:</td>
                <td>
                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Attribute Value" 
                        OnClick="btnAdd_Click" BackColor="#009900" ForeColor="White" />
                </td>
            </tr>
        </table>

        <br />

        <asp:GridView ID="gvProductAttributes" runat="server" AutoGenerateColumns="False" DataKeyNames="pro_att_id"
            OnRowEditing="gvProductAttributes_RowEditing" 
            OnRowCancelingEdit="gvProductAttributes_RowCancelingEdit" 
            OnRowUpdating="gvProductAttributes_RowUpdating" 
            OnRowDeleting="gvProductAttributes_RowDeleting">
            <Columns>
                <asp:BoundField DataField="pro_att_id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="prod_name" HeaderText="Product" ReadOnly="True" />
                <asp:BoundField DataField="att_name" HeaderText="Attribute" ReadOnly="True" />
                <asp:BoundField DataField="att_value" HeaderText="Value" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView></center>
    </form>
</body>
</html>
