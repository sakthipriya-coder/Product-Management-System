<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttributePage.aspx.cs" Inherits="WebApplication1.AttributePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Attributes</title>
</head>
<body>
    <form id="form1" runat="server"><center>
        <h2>Manage Attributes</h2>

        <table>
            <tr>
                <td>Attribute Name:</td>
                <td><asp:TextBox ID="txtAttributeName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Category:</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAddAttribute" runat="server" Text="Add Attribute" 
                        OnClick="btnAddAttribute_Click" BackColor="#009900" ForeColor="White" />
                </td>
            </tr>
        </table>

        <br />

        <!-- Attribute List -->
        <asp:GridView ID="gvAttributes" runat="server" AutoGenerateColumns="False" DataKeyNames="att_id"
            OnRowEditing="gvAttributes_RowEditing"
            OnRowCancelingEdit="gvAttributes_RowCancelingEdit"
            OnRowUpdating="gvAttributes_RowUpdating"
            OnRowDeleting="gvAttributes_RowDeleting">
            <Columns>
                <asp:BoundField DataField="att_id" HeaderText="Attribute ID" ReadOnly="True" />
                <asp:BoundField DataField="att_name" HeaderText="Attribute Name" />
                <asp:BoundField DataField="cat_name" HeaderText="Category" ReadOnly="True" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        </center>
    </form>
</body>
</html>
