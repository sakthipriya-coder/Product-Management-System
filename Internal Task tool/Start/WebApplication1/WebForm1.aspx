<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ffcccc" style="height: 668px">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
            style="z-index: 1; left: 347px; top: 53px; position: absolute; width: 699px; height: 56px; font-size: xx-large; text-align: center; font-family: 'Cooper Black'; text-decoration: underline" 
            Text="THIKSHA"></asp:Label>
    </p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img1.jpg" 
            style="z-index: 1; left: 384px; top: 109px; position: absolute; height: 376px; width: 647px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:Button ID="Button2" runat="server" BackColor="#FFFFCC" Font-Bold="True" 
        onclick="Button2_Click" 
        style="z-index: 1; left: 745px; top: 546px; position: absolute; height: 32px; width: 110px" 
        Text="Admin" />
    <p>
        &nbsp;</p>
    <asp:Button ID="Button1" runat="server" BackColor="#FFFFCC" Font-Bold="True" 
        style="z-index: 1; left: 564px; top: 545px; position: absolute; height: 32px; width: 104px" 
        Text="User" />
    </form>
</body>
</html>
