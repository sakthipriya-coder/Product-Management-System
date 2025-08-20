<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="WebApplication1.CategoryPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Category</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        .form-box { margin-bottom: 15px; }
        .msg { color: green; font-weight: bold; }
        .error { color: red; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server"><center>
        <h2>Manage Category</h2>

        <div class="form-box">
            <asp:Label ID="Label1" runat="server" Text="Category Name:" />
            <asp:TextBox ID="txtCategoryName" runat="server" />
            <asp:HiddenField ID="hfCatId" runat="server" />
        </div>

        <div class="form-box">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" 
                BackColor="#009933" ForeColor="White" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                OnClick="btnUpdate_Click" Visible="false" BackColor="#009900" 
                ForeColor="White" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                OnClick="btnCancel_Click" Visible="false" BackColor="#009900" 
                ForeColor="White" />
        </div>

        <asp:Label ID="lblMsg" runat="server" CssClass="msg" />

        <hr />

        <div class="form-box">
            <asp:TextBox ID="txtSearch" runat="server" Placeholder="Search by name" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>

        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="cat_id"
            OnRowCommand="gvCategories_RowCommand">
            <Columns>
                <asp:BoundField DataField="cat_id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="cat_name" HeaderText="Category Name" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" 
                            CommandName="EditCat" CommandArgument='<%# Eval("cat_id") %>' />
                        |
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" 
                            CommandName="DeleteCat" CommandArgument='<%# Eval("cat_id") %>'
                            OnClientClick="return confirm('Are you sure you want to delete this category?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></center>
    </form>
</body>
</html>
